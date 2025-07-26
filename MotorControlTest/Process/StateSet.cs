using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Process
{
    public enum CoordinationState
    {
        Idle = 0,
        Initializing,
        OriginDone,     //원점완료
        Standby,        //운전준비완료
        Wait,
        Axis1_Write_Move,
        Axis1_Write_Move_Check,
        Axis1_Verify_Move,
        Axis1_Verify_Move_Check,
        Axis2_Write_Move,
        Axis2_Write_Move_Check,
        Axis2_Verify_Move,
        Axis2_Verify_Move_Check,
        Pause,
        Stop,
        Alarm
    }


    public enum SocketState
    {
        Idle = 0,
        Homing,
        Ready,
        ReqLoad = 1000,
        ReqUnload = 2000,
        Req_Write,
        Req_Verify,
        Write_Complete,
        Verify_Complete,
        Error
    }



    // EEPROM Socket Stage용
    public enum eSocketState
    {
        EMPTY = 0,

        EXIST,                  // Write 전 Module 있음
        WRITE_END,              // Write 완료
        VERIFY_END,             // Verify 완료

        itemCount
    }
}
