using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest.Process.Socket
{
    public class ReadySocket
    {
        public ReadySocket()
        {

        }
        public int FlowRun(int nStep)                 //  원점(1000 ~ 2000)
        {
            string szLog = "";
            //bool bRtn = false;
            int nRetStep = nStep;
            switch (nStep)
            {
                case 1000:
                    szLog = $"[ReadySocket] Step - {nStep}";
                    Console.WriteLine(szLog);
                    nRetStep = 1100;
                    break;
                case 1100:
                    Console.WriteLine($"[ReadySocket] Step - {nStep}");
                    nRetStep = 1200;
                    break;
                case 1200:
                    Console.WriteLine($"[ReadySocket] Step - {nStep}");
                    nRetStep = 1800;
                    break;
                case 1800:
                    Console.WriteLine($"[ReadySocket] Step - {nStep}");
                    nRetStep = 1900;
                    break;
                case 1900:
                    Console.WriteLine($"[ReadySocket] Step - {nStep}");
                    nRetStep = 0;
                    //MessageBox.Show("Info", "운전준비 완료");

                    GlobalClass.threadManager.syncSocketController._currentState = Process.CoordinationState.Standby;
                    break;
                default:
                    //[ORIGIN] STEP ERR
                    nRetStep = -1;
                    break;
            }
            return nRetStep;
        }
    }
}
