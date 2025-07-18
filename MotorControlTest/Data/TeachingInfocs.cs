using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class TransferTeachInfo
    {
        public enum eteach : int
        {
            POSITION1_POS = 0, POSITION2_POS, POSITION3_POS, TRANSFER_TEACHING_COUNT
        };
        public static string[] eteachName = 
        {
            "POSITION1_POS","POSITION2_POS", "POSITION3_POS"
        };
    }


    public class SocketTeachInfo
    {
        public enum eteach : int
        {
            S1_POS = 0, S2_POS, S3_POS, SOCKET_TEACHING_COUNT
        };
        public static string[] eteachName =
        {
            "S1_POS","S2_POS", "S3_POS"
        };
    }

    public class MagazineTeachInfo
    {
        public enum eteach : int
        {
            M1_POS = 0, M2_POS, M3_POS, MAGAZINE_TEACHING_COUNT
        };
        public static string[] eteachName =
        {
            "M1_POS","M2_POS", "M3_POS"
        };
    }
}
