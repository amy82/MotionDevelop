﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest
{
    public class GlobalClass
    {
        public static Data.DataManager dataManager = new Data.DataManager();
        public static Machine.MotionManager motionManager;

        public static Fthread.ThreadManager threadManager;


        //Process
        public static Process.ProcessManager processManager;


        //Dlg
        public static Dlg.UnitControl unitControl;
    }
}
