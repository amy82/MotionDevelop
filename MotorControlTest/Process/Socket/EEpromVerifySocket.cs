using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Process.Socket
{
    public class EEpromVerifySocket
    {
        private string[] socketName = { "X - Socket", "XY - socket" };
        public int nTimeTick = 0;
        public EEpromVerifySocket()
        {

        }
        public int FlowRun(int nStep, int index)                 //  원점(1000 ~ 2000)
        {
            string szLog = "";
            //bool bRtn = false;
            int nRetStep = nStep;
            switch (nStep)
            {
                case 1000:
                    szLog = $"[EEpromVerifySocket] {socketName[index]} START - {nStep}";
                    Console.WriteLine(szLog);
                    nRetStep = 1100;
                    break;
                case 1100:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Verify Pos Check {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1102;
                    break;
                case 1102:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact UP {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1104;
                    break;
                case 1104:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact FOR {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1106;
                    break;
                case 1106:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact DOWN {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1108;
                    break;
                case 1108:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Verify Test Start {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1110;
                    break;
                case 1110:
                    if (Environment.TickCount - nTimeTick > 5000)
                    {
                        nRetStep = 1200;
                    }
                    break;
                case 1200:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Verify Test End {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1202;
                    break;
                case 1202:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact Up {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1204;
                    break;
                case 1204:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact Back {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1206;
                    break;
                case 1206:
                    Console.WriteLine($"[EEpromVerifySocket] {socketName[index]} Contact Down {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1220;
                    break;
                case 1220:
                    Console.WriteLine($"[EEpromVerifySocket] EEPROM VERIFY Complete - {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1900;
                    break;
                case 1900:
                    Console.WriteLine($"[EEpromVerifySocket] Step - {nStep}");
                    if (index == 0)
                    {
                        GlobalClass.threadManager.hybridThreadManager._socket1.CurrentState = Data.SocketState.Verify_Complete;
                    }
                    else
                    {
                        GlobalClass.threadManager.hybridThreadManager._socket2.CurrentState = Data.SocketState.Verify_Complete;
                    }
                    nRetStep = 0;
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
