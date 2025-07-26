using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.UnitControl
{
    public class SocketUnit
    {
        public int MotorCnt { get; private set; } = 2;

        public Data.eSocketState[] socketState;
        public string[] axisName = { "SocketX", "SocketY" };

        public string teachingPath = "SocketTeaching.ini";
        public string taskWorkPath = "SocketTaskWork.ini";

        public const int socketCount = 4;
        public SocketUnit()
        {
            int i = 0;
            
            socketState = new Data.eSocketState[socketCount];
            for (i = 0; i < socketState.Length; i++)
            {
                socketState[i] = Data.eSocketState.EMPTY;
            }
        }
        public bool taskSave()
        {
            return true;
        }

        public bool taskLoad()
        {
            return true;
        }
    }
}
