using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Machine
{
    public class MotionManager
    {
        public Machine.TransferMachine transferMachine;
        public Machine.MagazineMachine magazineMachine;
        public Machine.SocketMachine socketMachine;

        public MotionManager()
        {
            transferMachine = new TransferMachine();
            magazineMachine = new MagazineMachine();
            socketMachine = new SocketMachine();
        }
    }
}
