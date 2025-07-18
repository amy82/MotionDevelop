using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Machine
{
    public class SocketMachine
    {
        public int MotorCnt { get; private set; } = 2;
        public string[] axisName = { "SocketX", "SocketY" };

        public string teachingPath = "SocketTeaching.ini";
        public SocketMachine()
        {

        }
    }
}
