using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread.Socket
{
    public class SocketX : BaseThread, IAxisController
    {
        public bool IsBusy { get; set; }
        public Data.SocketState CurrentState { get; set; }
        public int m_nCurrentStep = 0;
        public SocketX()
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
        public void ReadyStart()
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
            switch (CurrentState)
            {
                case Data.SocketState.Idle:

                    break;
            }
            
            if (m_nCurrentStep == 0)
            {

            }
            else if (m_nCurrentStep >= 1000 && m_nCurrentStep < 2000)
            {
                //공급요청
            }
            else if (m_nCurrentStep >= 2000 && m_nCurrentStep < 3000)
            {
                //배출요청
            }
            else if (m_nCurrentStep >= 3000 && m_nCurrentStep < 4000)
            {
                //Write Test
            }
            else if (m_nCurrentStep >= 4000 && m_nCurrentStep < 5000)
            {
                //Verify Test
            }
        }
    }
}
