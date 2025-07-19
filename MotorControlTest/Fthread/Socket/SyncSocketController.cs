using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread.Socket
{
    public class SyncSocketController : BaseThread
    {
        public int CurrentStep { get; set; }
        
        private readonly IAxisController socketx;
        private readonly IAxisController socketxy;


        public Data.CoordinationState _currentState = Data.CoordinationState.Initializing;
        public SyncSocketController(IAxisController _socketx, IAxisController _socketxy)
        {
            this.socketx = _socketx;
            this.socketxy = _socketxy;
        }
        protected override void ThreadInit()
        {

        }

        protected override void ThreadDestructor()
        {

        }

        public void ReadyStart()
        {
            if (_currentState != Data.CoordinationState.Initializing)
            {
                _currentState = Data.CoordinationState.Standby;
            }
            CurrentStep = 1000;

            this.Start();

        }
        protected override void ThreadRun()
        {

            if (CurrentStep == 0)
            {
                //IDLE
                Stop();
            }
            else if (CurrentStep > 0)
            {
                switch (_currentState)
                {
                    case Data.CoordinationState.Initializing:
                        CurrentStep = GlobalClass.threadManager.processManager.homeSocket.FlowRun(CurrentStep);
                        break;

                    case Data.CoordinationState.OriginDone:
                    case Data.CoordinationState.Standby:
                        CurrentStep = GlobalClass.threadManager.processManager.readySocket.FlowRun(CurrentStep);
                        break;

                    case Data.CoordinationState.Wait:
                        CurrentStep = GlobalClass.threadManager.processManager.waitSocket.FlowRun(CurrentStep);
                        break;
                }
            }
            else
            {
                //일시정지 , Alarm
                Pause();

            }

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {

        }
        private void UpdateUI()
        {

        }
    }
}
