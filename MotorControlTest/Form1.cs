using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest
{
    public partial class Form1 : Form
    {
        public Data.TeachingData teachingData = new Data.TeachingData();
        public Form1()
        {
            InitializeComponent();


            GlobalClass.motionManager = new Machine.MotionManager();
            GlobalClass.threadManager = new Fthread.ThreadManager();
            GlobalClass.unitControl = new Dlg.UnitControl();

            GlobalClass.processManager = new Process.ProcessManager();

            this.Controls.Add(GlobalClass.unitControl);
        }

        private void btn_Ini_Load_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Ini_Save_Click(object sender, EventArgs e)
        {

        }
    }
}
