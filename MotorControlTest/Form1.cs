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
        
        public Form1()
        {
            InitializeComponent();

            //DATA
            GlobalClass.dataManager = new Data.DataManager();

            //MOTION
            GlobalClass.motionManager = new Machine.MotionManager();
            GlobalClass.threadManager = new Fthread.ThreadManager();

            //UI
            GlobalClass.unitControl = new Dlg.UnitControl();




            GlobalClass.dataManager.teachingData.testLoad();
            GlobalClass.dataManager.taskWorkData.testLoad();

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
