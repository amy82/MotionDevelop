using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MotorControlTest.Fthread
{
    

    public class HybridThreadManager : IDisposable
    {
        // 모니터링 스레드
        public readonly SocketThread _socket1;
        public readonly SocketThread _socket2;


        // 종료 플래그
        //private volatile bool _isRunning = true;

        private readonly System.Timers.Timer _controlTimer;

        public Process.CoordinationState _currentState = Process.CoordinationState.Initializing;

        public int m_nCurrentStep = 0;
        private readonly object _stateLock = new object();
        public HybridThreadManager()
        {
            // 모니터링 시작
            
            _controlTimer = new System.Timers.Timer(500)//10)  // 10ms 제어 주기 (고정밀)
            {
                AutoReset = true,
                SynchronizingObject = null
            };
            _controlTimer.Elapsed += ControlLoop;

            _socket1 = new SocketThread(0, RequestStateChange);
            _socket2 = new SocketThread(1, RequestStateChange);
        }
        // 상태 변경 요청을 처리하는 메서드
        private void RequestStateChange(Process.CoordinationState newState, int sourceId)
        {
            // 스레드 안전한 상태 변경
            lock (_stateLock)
            {
                _currentState = newState;
                Console.WriteLine($"[State Change] Source: {sourceId}, New State: {newState}");
                // 상태 전환 로직 검증
                //if (IsValidStateTransition(_currentState, newState))
                //{
                //    _currentState = newState;
                //    Console.WriteLine($"[State Change] Source: {sourceId}, New State: {newState}");
                //}
            }
        }
        public void ReadyStart()
        {
            if (_controlTimer.Enabled == true)
            {
                Console.WriteLine("운전준비 중입니다.");
                return;
            }
            if (_currentState != Process.CoordinationState.Initializing)
            {
                _currentState = Process.CoordinationState.Standby;
            }
            m_nCurrentStep = 1000;

            _controlTimer.Start();
        }
        public void Start()
        {
            if (_controlTimer.Enabled == false)     //정지상태
            {
                if (_currentState != Process.CoordinationState.Standby)
                {
                    Console.WriteLine("운전준비 상태가 아닙니다..");
                    return;
                }

                Console.WriteLine("자동운전 Start");
                m_nCurrentStep = 1;
                _currentState = Process.CoordinationState.Wait;

                _controlTimer.Start();

                _socket1.m_nCurrentStep = 1000;
                _socket2.m_nCurrentStep = 1000;
                _socket1.Start();
                _socket2.Start();
            }
            else
            {
                if (_currentState == Process.CoordinationState.Pause)
                {
                    //일시 정지 상태
                    Console.WriteLine("일시정지 해제");
                    _controlTimer.Start();

                    if (_socket1.GetThreadPause() == true)
                    {
                        Console.WriteLine("_socket1 운전 재시작");
                        _socket1.Resume();
                    }

                    if (_socket2.GetThreadPause() == true)
                    {
                        Console.WriteLine("_socket2 운전 재시작");
                        _socket2.Resume();
                    }
                }
                else
                {
                    Console.WriteLine("자동운전 중입니다...!!!");
                }
            }
        }
        public void Stop()
        {
            _currentState = Process.CoordinationState.Idle;
            _controlTimer.Stop();
            _socket1.Stop();
            _socket2.Stop();
        }
        public void Pause()
        {
            _currentState = Process.CoordinationState.Alarm;
            _controlTimer.Stop();
            if (_socket1.GetThreadRun() == true)
            {
                _socket1.Pause();
            }
            if (_socket2.GetThreadRun() == true)
            {
                _socket2.Pause();
            }
        }
        private void ControlLoop(object sender, ElapsedEventArgs e)
        {
            // 동기화 상태 머신 실행
            Console.WriteLine($"ControlLoop 작업 중...[{_currentState}]");

            ExecuteStateMachine();
        }
        private void ExecuteStateMachine()
        {
            if (m_nCurrentStep == 0)
            {
                //IDLE
                
                _controlTimer.Stop();
            }
            else if (m_nCurrentStep > 0)
            {
                switch (_currentState)
                {
                    case Process.CoordinationState.Initializing:
                        m_nCurrentStep = GlobalClass.threadManager.processManager.homeSocket.FlowRun(m_nCurrentStep);
                        break;

                    case Process.CoordinationState.OriginDone:
                    case Process.CoordinationState.Standby:
                        m_nCurrentStep = GlobalClass.threadManager.processManager.readySocket.FlowRun(m_nCurrentStep);
                        break;

                    case Process.CoordinationState.Wait:
                        m_nCurrentStep = GlobalClass.threadManager.processManager.waitSocket.FlowRun(m_nCurrentStep);
                        break;
                }
            }
            else
            {
                //일시정지 , Alarm
                Pause();
                
            }
        }
        private void InitializeSystem()
        {
        }

        
        
        // 리소스 정리
        public void Dispose()
        {
            // 모니터링 스레드 정상 종료 대기
            _controlTimer.Stop();

            Console.WriteLine("HybridThreadManager disposed");
        }
    }
}
