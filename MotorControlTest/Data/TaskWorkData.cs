using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class TaskWorkData
    {


        public int[] SocketTaskWorkArr;


        public TaskWorkData()
        {
            SocketTaskWorkArr = new int[Machine.SocketMachine.socketCount];

        }

        public bool Load()
        {
            return true;
        }

        public bool Save()
        {
            return true;
        }
    }
}
