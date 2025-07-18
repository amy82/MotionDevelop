using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Machine
{
    public class TransferMachine
    {
        public int MotorCnt { get; private set; } = 3;
        public string[] axisName = { "TransferX", "TransferY", "TransferZ" };

        public string teachingPath = "TransferTeaching.ini";
        public TransferMachine()
        {

        }
    }
}
