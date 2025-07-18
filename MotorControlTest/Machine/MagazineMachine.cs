using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Machine
{
    public class MagazineMachine
    {
        public int MotorCnt { get; private set; } = 2;
        public string[] axisName = { "MagazineY", "MagazineZ" };

        public string teachingPath = "MagazineTeaching.ini";
        public MagazineMachine()
        {

        }
    }
}
