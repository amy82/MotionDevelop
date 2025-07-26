using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class TeachingPoint
    {
        public string Name { get; set; }
        public double[] Pos { get; set; }
    }


    public class TaskWorkPoint
    {
        public string Name { get; set; }
        public int[] State { get; set; }
    }
    public enum eModuleJudge
    {
        INSPECTION = 0,
        OK,
        NG,

        itemCount
    }
    public enum ePickedProductState
    {
        EMPTY = 0,          // 제품 없음    
        Bcr,                //투입할 제품 로드 상태
        BcrNg,              // 불량

        Good,               // 양품. (EEPROM의 경우 Write와 Verify를 모두 OK 판정을 받은 Module)
        TestNg1,            //aoi , fw , write
        TestNg2,            //verify

        TestOk1,            // EEPROM 설비의 Write OK 상태
        //itemCount
    }

    //public MODULE_INFO[][] moduleInfo;
    public class MODULE_INFO
    {
        // string type : 이름을 대문자로 통일
        // 그 외 : 소문자로 시작

        public string LOTID;
        public string MODULEID;                 // Bcr Scan Data
        public string TRAYID;

        public int originRow;                   // fromRow로 변경
        public int OriginCol;                   // fromCol로 변경
        public int finalRow;                    // toRow로 변경
        public int finalCol;                    // toCol로 변경

        public eModuleJudge moduleJudge;        // integer로 관리 (0:BEFORE, OK:1, 나머지는 알아서 정의)
        public ePickedProductState bcrState;    // BEFORE, OK, NG 만 관리 (integer)

        public string NgCode;                   // NGCODE : 검사기에서 넘어오는 Code
        // Special Data                           // SPECIALDATA : 검사기에서 넘어오는 Special Data

        public int fromTrayIndex;

        object _lock = new object();

        public MODULE_INFO()
        {
            LOTID = string.Empty;
            MODULEID = string.Empty;
            TRAYID = string.Empty;
            fromTrayIndex = -1;
            moduleJudge = eModuleJudge.itemCount;
            bcrState = ePickedProductState.EMPTY;
            NgCode = string.Empty;
            originRow = OriginCol = finalRow = finalCol = -1;
        }

        public void Init()
        {
            lock (_lock)
            {
                LOTID = string.Empty;
                TRAYID = string.Empty;
                MODULEID = string.Empty;
                fromTrayIndex = -1;
                moduleJudge = eModuleJudge.itemCount;
                bcrState = ePickedProductState.EMPTY;
                NgCode = string.Empty;
                originRow = OriginCol = finalRow = finalCol = -1;
            }
        }

        public void setNewModuleData(string sTrayId, int fromTray, int nRow, int nCol)
        {
            lock (_lock)
            {
                TRAYID = sTrayId;
                fromTrayIndex = fromTray;
                originRow = nRow;
                OriginCol = nCol;
                finalRow = -1;
                finalCol = -1;
                bcrState = ePickedProductState.EMPTY;
            }
        }

        public void setData(MODULE_INFO pData)
        {
            lock (_lock)
            {
                LOTID = pData.LOTID;
                MODULEID = pData.MODULEID;
                TRAYID = pData.TRAYID;
                fromTrayIndex = pData.fromTrayIndex;
                moduleJudge = pData.moduleJudge;
                NgCode = pData.NgCode;

                bcrState = pData.bcrState;
                originRow = pData.originRow;
                OriginCol = pData.OriginCol;
                finalRow = pData.finalRow;
                finalCol = pData.finalCol;
            }
        }

        public MODULE_INFO getData()
        {
            lock (_lock)
            {
                MODULE_INFO retData = new MODULE_INFO();

                retData.LOTID = LOTID;
                retData.MODULEID = MODULEID;
                retData.TRAYID = TRAYID;

                retData.fromTrayIndex = fromTrayIndex;
                retData.moduleJudge = moduleJudge;
                retData.NgCode = NgCode;
                retData.bcrState = bcrState;
                retData.originRow = originRow;
                retData.OriginCol = OriginCol;
                retData.finalRow = finalRow;
                retData.finalCol = finalCol;

                return retData;
            }
        }

        public void resetData()
        {
            lock (_lock)
            {
                LOTID = string.Empty;
                MODULEID = string.Empty;
                TRAYID = string.Empty;
                fromTrayIndex = -1;
                moduleJudge = eModuleJudge.itemCount;
                bcrState = ePickedProductState.EMPTY;
                NgCode = string.Empty;
                originRow = OriginCol = finalRow = finalCol = -1;
            }
        }
    }
}
