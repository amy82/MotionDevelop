using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest.Dlg
{
    public partial class UnitControl : UserControl
    {
        public UnitControl()
        {
            InitializeComponent();
        }

        private void btn_Socekt_Ready_Click(object sender, EventArgs e)
        {
            //GlobalClass.threadManager.hybridThreadManager.ReadyStart();
            GlobalClass.threadManager.syncSocketController.ReadyStart();

        }

        private void btn_Socekt_Pause_Click(object sender, EventArgs e)
        {
            GlobalClass.threadManager.hybridThreadManager.Pause();
        }

        private void btn_Socekt_Start_Click(object sender, EventArgs e)
        {
            //GlobalClass.threadManager.hybridThreadManager.socketRun();
            GlobalClass.threadManager.hybridThreadManager.Start();
        }

        private void btn_Socekt_Stop_Click(object sender, EventArgs e)
        {
            GlobalClass.threadManager.hybridThreadManager.Stop();
        }
    }
}
