using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class SocketTaskWorkInfo
    {
        public enum eState : int
        {
            POSITION1_POS = 0, TRANSFER_TEACHING_COUNT
        };
        public static string[] estateName =
        {
            "POSITION1_POS","POSITION2_POS", "POSITION3_POS"
        };
    }
}
