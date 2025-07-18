using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread
{
    public class SocketThread : BaseThread
    {
        public Data.SocketState CurrentState {get; set;}
        public int m_nCurrentStep = 0;
        public int m_nStartStep = 0;
        public int m_nEndStep = 0;
        public bool IsBusy { get; set; }

        public int[] m_nSocketStep = { 0, 0, 0, 0 };
        public int Index;

        private readonly Action<Data.CoordinationState, int> _stateChangeCallback;
        public SocketThread(int index, Action<Data.CoordinationState, int> stateChangeCallback)
        {
            this.Index = index;
            this._stateChangeCallback = stateChangeCallback;
            this.IsBusy = false;
            CurrentState = Data.SocketState.Idle;

        }
        protected override void ThreadInit()
        {
            this.IsBusy = false;
            Console.WriteLine($"Socket {this.Index} ThreadInit");
        }

        protected override void ThreadDestructor()
        {
            this.IsBusy = false;
            Console.WriteLine($"Socket {this.Index} ThreadDestructor");
        }
        protected override void ThreadRun()
        {
            if (this.m_nCurrentStep == 0)
            {
                //IDLE
                return;
            }
            else if (this.m_nCurrentStep > 0)
            {
                
                if (this.Index == 0)
                {
                    //X축 소켓
                    if (this.CurrentState == Data.SocketState.Req_Write)
                    {
                        //1.컨택 전체 상승 확인
                        //2.x축 Write Pos Move
                        //3.컨택 전진 , 하강
                        //4.EEprom Write 진행신호
                        //5.EEprom Write 검사 대기
                        //6.Write 검사 완료 처리
                        this.IsBusy = true;
                        this.m_nCurrentStep = GlobalClass.processManager.eepromWriteSocket.FlowRun(this.m_nCurrentStep, this.Index);
                    }
                    if (this.CurrentState == Data.SocketState.Req_Verify)
                    {
                        this.IsBusy = true;
                        this.m_nCurrentStep = GlobalClass.processManager.eepromVerifySocket.FlowRun(this.m_nCurrentStep, this.Index);
                    }
                }
                else
                {
                    //X축 + Y실린더 소켓
                    if (this.CurrentState == Data.SocketState.Req_Write)
                    {
                        this.IsBusy = true;
                        this.m_nCurrentStep = GlobalClass.processManager.eepromWriteSocket.FlowRun(this.m_nCurrentStep, this.Index);
                    }
                    if (this.CurrentState == Data.SocketState.Req_Verify)
                    {
                        this.IsBusy = true;
                        this.m_nCurrentStep = GlobalClass.processManager.eepromVerifySocket.FlowRun(this.m_nCurrentStep, this.Index);
                    }
                }
            }
            else
            {
                this.IsBusy = false;
                this.Pause();
                _stateChangeCallback?.Invoke(Data.CoordinationState.Alarm, this.Index);
                Console.WriteLine($"socket {this.Index} Process pause");
            }
        }
        public void StartProcess(int startStep, int endStep)
        {
            if (CurrentState == Data.SocketState.Ready)
            {
                this.m_nStartStep = startStep;
                this.m_nEndStep = endStep;
                this.Start();
            }
        }

        public void StopProcess()
        {
            IsBusy = false;
            this.CurrentState = Data.SocketState.Idle;
            this.Stop();
            CurrentState = Data.SocketState.Idle;
        }
    }
}
