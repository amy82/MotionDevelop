using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread.Socket
{
    public class SocketXY : BaseThread, IAxisController
    {
        public bool IsTesting { get; set; }
        public Data.SocketState CurrentState { get; set; }

        public SocketXY()
        {
            CurrentState = Data.SocketState.Idle;
        }
        public int ExecuteReadyStep(int currentStep)
        {
            // 갠트리 특화 홈 스텝 로직
            return currentStep + 10;
        }
        public int ExecuteHomeStep(int currentStep)
        {
            // 갠트리 특화 홈 스텝 로직
            return currentStep + 10;
        }
        public void SetPause(bool pause)
        {
        }

        public void Reset()
        {

        }
        protected override void ThreadInit()
        {

        }

        protected override void ThreadDestructor()
        {

        }


        protected override void ThreadRun()
        {
        }
    }
}
