using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.UnitControl
{
    public class MagazineUnit
    {
        public int MotorCnt { get; private set; } = 2;
        public string[] axisName = { "MagazineY", "MagazineZ" };

        public string teachingPath = "MagazineTeaching.ini";
        public MagazineUnit()
        {

        }
    }
}
