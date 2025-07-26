using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.UnitControl
{
    public class LiftUnit
    {
        public int MotorCnt { get; private set; } = 4;
        public string[] axisName = { "GantryX1", "GantryX2", "LoadZ", "UnloadZ" };

        public string teachingPath = "LiftTeaching.ini";

        public Data.MODULE_INFO[][] moduleInfoArr;

        public const int TrayMaxRow = 4;    //가로
        public const int TrayMaxCol = 11;

        public int UseTrayRow = TrayMaxRow;     //수시로 사용할 tray 개수 변경
        public int UseTrayCol = TrayMaxCol;
        public LiftUnit()
        {
            int i = 0;
            int j = 0;
            moduleInfoArr = new Data.MODULE_INFO[TrayMaxRow][];

            for (i = 0; i < TrayMaxRow; i++)
            {
                moduleInfoArr[i] = new Data.MODULE_INFO[TrayMaxCol];
                for (j = 0; j < TrayMaxCol; j++)
                {
                    moduleInfoArr[i][j] = new Data.MODULE_INFO();
                }
            }

            //moduleInfoArr[0] = new Data.MODULE_INFO[10];
            //moduleInfoArr[1] = new Data.MODULE_INFO[10];
            //moduleInfoArr[2] = new Data.MODULE_INFO[10];
            //moduleInfoArr[3] = new Data.MODULE_INFO[10];
            //moduleInfoArr[0][0] = new Data.MODULE_INFO();
            //moduleInfoArr[0][1] = new Data.MODULE_INFO();

            //moduleInfoArr[1][0] = new Data.MODULE_INFO();
            //moduleInfoArr[1][1] = new Data.MODULE_INFO();

        }
    }
}
