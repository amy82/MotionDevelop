using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread
{
    public interface IAxisController
    {
        bool IsTesting { get; set; }
        Process.SocketState CurrentState { get; set; }
        int ExecuteHomeStep(int currentStep);
        int ExecuteReadyStep(int currentStep);
        void SetPause(bool paused);
        void Reset();
    }
}
