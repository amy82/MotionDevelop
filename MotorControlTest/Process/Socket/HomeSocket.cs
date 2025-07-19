using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest.Process.Socket
{
    public class HomeSocket
    {
        public HomeSocket()
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
                    szLog = $"[HomeSocket] Step - {nStep}";
                    Console.WriteLine(szLog);
                    nRetStep = 1100;
                    break;
                case 1100:
                    Console.WriteLine($"[HomeSocket] Step - {nStep}");
                    nRetStep = 1200;
                    break;
                case 1200:
                    Console.WriteLine($"[HomeSocket] Step - {nStep}");
                    nRetStep = 1800;
                    break;
                case 1800:
                    Console.WriteLine($"[HomeSocket] Step - {nStep}");
                    nRetStep = 1900;
                    break;
                case 1900:
                    Console.WriteLine($"[HomeSocket] Step - {nStep}");
                    nRetStep = 0;
                    //MessageBox.Show("Info", "원점완료");//, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    GlobalClass.threadManager.syncSocketController._currentState = Data.CoordinationState.OriginDone;
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
