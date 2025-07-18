using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Process.Socket
{
    public class AutoRunSocket
    {
        public int nTimeTick = 0;
        public AutoRunSocket()
        {

        }
        public int FlowRun(int nStep)                 //  원점(1000 ~ 2000)
        {
            string szLog = "";
            bool bRtn = false;
            int nRetStep = nStep;
            switch (nStep)
            {
                case 1000:
                    szLog = $"[AutoRunSocket] Step - {nStep}";
                    Console.WriteLine(szLog);
                    nRetStep = 1100;
                    break;
                case 1100:
                    Console.WriteLine($"[AutoRunSocket] Write Motor Move - {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1110;
                    break;
                case 1110:
                    if (Environment.TickCount - nTimeTick > 5000)
                    {
                        nRetStep = 1120;
                    }
                    break;
                case 1120:
                    Console.WriteLine($"[AutoRunSocket] Write Motor Move Complete- {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1200;
                    break;
                case 1200:
                    Console.WriteLine($"[AutoRunSocket] EEPROM WRITE Start - {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1210;
                    break;
                case 1210:
                    if (Environment.TickCount - nTimeTick > 5000)
                    {
                        nRetStep = 1220;
                    }
                    break;
                case 1220:
                    Console.WriteLine($"[AutoRunSocket] EEPROM WRITE Complete - {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1800;
                    break;
                case 1800:
                    Console.WriteLine($"[AutoRunSocket] EEPROM WRITE End - {nStep}");
                    nTimeTick = Environment.TickCount;
                    nRetStep = 1900;
                    break;
                case 1900:
                    Console.WriteLine($"[AutoRunSocket] Step - {nStep}");
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
