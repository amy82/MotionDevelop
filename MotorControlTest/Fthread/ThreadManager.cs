using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Fthread
{
    public class ThreadManager
    {
        public HybridThreadManager hybridThreadManager;


        //
        // SOCKET CLASS
        //
        public Socket.SyncSocketController syncSocketController;
        public Socket.SocketX socketx;
        public Socket.SocketXY socketxy;

        //
        public ThreadManager()
        {
            hybridThreadManager = new HybridThreadManager();


            socketx = new Socket.SocketX();
            socketxy = new Socket.SocketXY();
            //_liftCtrl = new LiftController();
            syncSocketController = new Socket.SyncSocketController(socketx, socketxy);
        }
    }
}
