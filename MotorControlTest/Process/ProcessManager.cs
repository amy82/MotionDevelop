using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Process
{
    public class ProcessManager
    {
        //SOCKET FLOW
        public Socket.HomeSocket homeSocket;
        public Socket.ReadySocket readySocket;
        public Socket.WaitSocket waitSocket;
        public Socket.EEpromWriteSocket eepromWriteSocket;
        public Socket.EEpromVerifySocket eepromVerifySocket;

        public Socket.AutoRunSocket autoRunSocket;


        //

        public ProcessManager()
        {
            homeSocket = new Socket.HomeSocket();
            readySocket = new Socket.ReadySocket();
            waitSocket = new Socket.WaitSocket();
            eepromWriteSocket = new Socket.EEpromWriteSocket();
            eepromVerifySocket = new Socket.EEpromVerifySocket();


            autoRunSocket = new Socket.AutoRunSocket();
        }
    }
}
