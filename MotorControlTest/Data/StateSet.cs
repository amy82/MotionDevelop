using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public enum CoordinationState
    {
        Idle = 0,
        Initializing,
        OriginDone,     //원점완료
        Standby,        //운전준비완료
        Pause,
        Stop,
        Wait,
        Axis1_Write,
        Axis1_Verify,
        Axis2_Write,
        Axis2_Verify,
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
}
