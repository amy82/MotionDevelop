using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest.Data
{
    public class TaskWorkData
    {

        public TaskWorkPoint LeftSocketTaskWork;
        public TaskWorkPoint RightSocketTaskWork;

        public TaskWorkData()
        {
            int i = 0;
            LeftSocketTaskWork = new TaskWorkPoint();
            RightSocketTaskWork = new TaskWorkPoint();
            LeftSocketTaskWork.Name = "LEFT_SOCKET";
            RightSocketTaskWork.Name = "RIGHT_SOCKET";

            LeftSocketTaskWork.moduleInfo = new MODULE_INFO[UnitControl.SocketUnit.socketCount];
            RightSocketTaskWork.moduleInfo = new MODULE_INFO[UnitControl.SocketUnit.socketCount];

            LeftSocketTaskWork.State = new int[UnitControl.SocketUnit.socketCount];
            RightSocketTaskWork.State = new int[UnitControl.SocketUnit.socketCount];

            for (i = 0; i < LeftSocketTaskWork.State.Length; i++)
            {
                LeftSocketTaskWork.State[i] = 0;
            }
            for (i = 0; i < RightSocketTaskWork.State.Length; i++)
            {
                RightSocketTaskWork.State[i] = 0;
            }

            for (i = 0; i < LeftSocketTaskWork.moduleInfo.Length; i++)
            {
                LeftSocketTaskWork.moduleInfo[i] = new MODULE_INFO();
                LeftSocketTaskWork.moduleInfo[i].Init();
            }
            for (i = 0; i < RightSocketTaskWork.moduleInfo.Length; i++)
            {
                RightSocketTaskWork.moduleInfo[i] = new MODULE_INFO();
                RightSocketTaskWork.moduleInfo[i].Init();
            }
        }
        public void testSave()
        {
            Save(GlobalClass.motionManager.socketUnit.taskWorkPath, LeftSocketTaskWork);
            Save(GlobalClass.motionManager.socketUnit.taskWorkPath, RightSocketTaskWork);
        }
        public void testLoad()
        {
            Load(GlobalClass.motionManager.socketUnit.taskWorkPath, ref LeftSocketTaskWork);
            Load(GlobalClass.motionManager.socketUnit.taskWorkPath, ref RightSocketTaskWork);
        }
        public bool Load(string filename, ref TaskWorkPoint TPoint)
        {
            try
            {
                int i = 0;
                int j = 0;
                string iniPath = System.IO.Path.Combine(Application.StartupPath, filename);
                GlobalClass.dataManager.inifile.Path = iniPath;

                string defaultValue = DataManager.GetDefaultValue(TPoint.State.Length, 0);

                string name = TPoint.Name;
                string section = $"{name}";
                string posStr = GlobalClass.dataManager.inifile.Read(section, "State", defaultValue);
                string[] posTokens = posStr.Split(',');
                TaskWorkPoint tp = new TaskWorkPoint();
                tp.Name = name;
                tp.State = new int[TPoint.State.Length];
                for (j = 0; j < TPoint.State.Length; j++)
                {
                    tp.State[j] = int.Parse(posTokens[j]);
                }
                ///tp.Pos = (double[])pos.Clone(); //배열 자체를 복사!

                //TPoint = tp;



                for (i = 0; i < TPoint.moduleInfo.Length; i++)
                {
                    section = name + "_MODULE" + (i + 1).ToString();
                    TPoint.moduleInfo[i].LOTID = GlobalClass.dataManager.inifile.Read(section, "LOTID", "EMPTY");
                    TPoint.moduleInfo[i].MODULEID = GlobalClass.dataManager.inifile.Read(section, "MODULEID", "EMPTY");
                    TPoint.moduleInfo[i].TRAYID = GlobalClass.dataManager.inifile.Read(section, "TRAYID", "EMPTY");
                }
                
                

                
            }
            catch (Exception ex)
            {
                // 로그 출력 (필요하면 로그 파일로도 가능)
                Console.WriteLine("Teaching 로드 중 오류 발생: " + ex.Message);

                // 사용자 메시지
                MessageBox.Show("Teaching 로드 실패:\n" + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; // 저장 실패
            }
            return true;
        }

        public bool Save(string filename, TaskWorkPoint TPoint)
        {

            //_stprintf_s(szIniBuff, SIZE_OF_1K, _T("%d / %d"), TransferTask.m_nTransferPickupState[0], TransferTask.m_nTransferPickupState[1]);
            //WritePrivateProfileString(_T("TRANSFER_WORK"), _T("PickerState"), szIniBuff, szPath);
            /*
             [LEFT_SOCKET_STATE]
                State=3,4,5,6
             */
            try
            {
                int i = 0;
                string iniPath = System.IO.Path.Combine(Application.StartupPath, filename);
                GlobalClass.dataManager.inifile.Path = iniPath;

                string section = TPoint.Name;
                for (i = 0; i < TPoint.State.Length; i++)
                {
                    GlobalClass.dataManager.inifile.Write(section, "State", string.Join(",", TPoint.State));
                }
                string inSection = string.Empty;
                for (i = 0; i < TPoint.moduleInfo.Length; i++)
                {
                    inSection = section + "_MODULE" + (i + 1).ToString();

                    GlobalClass.dataManager.inifile.Write(inSection, "LOTID", TPoint.moduleInfo[i].LOTID);
                    GlobalClass.dataManager.inifile.Write(inSection, "MODULEID", TPoint.moduleInfo[i].MODULEID);
                    GlobalClass.dataManager.inifile.Write(inSection, "TRAYID", TPoint.moduleInfo[i].TRAYID);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("TaskWork 저장 중 오류 발생: " + ex.Message);
                MessageBox.Show("TaskWork 저장 실패:\n" + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 저장 실패
            }
            return true;
        }
    }
}
