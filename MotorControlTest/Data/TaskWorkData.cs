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
            LeftSocketTaskWork.Name = "LEFT_SOCKET_STATE";
            RightSocketTaskWork.Name = "RIGHT_SOCKET_STATE";

            LeftSocketTaskWork.State = new int[Machine.SocketMachine.socketCount];
            RightSocketTaskWork.State = new int[Machine.SocketMachine.socketCount];

            for (i = 0; i < LeftSocketTaskWork.State.Length; i++)
            {
                LeftSocketTaskWork.State[i] = 0;
            }
            for (i = 0; i < RightSocketTaskWork.State.Length; i++)
            {
                RightSocketTaskWork.State[i] = 0;
            }
        }
        public void testSave()
        {
            Save(GlobalClass.motionManager.socketMachine.taskWorkPath, LeftSocketTaskWork);
            Save(GlobalClass.motionManager.socketMachine.taskWorkPath, RightSocketTaskWork);
        }
        public void testLoad()
        {
            Load(GlobalClass.motionManager.socketMachine.taskWorkPath, ref LeftSocketTaskWork);
            Load(GlobalClass.motionManager.socketMachine.taskWorkPath, ref RightSocketTaskWork);
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

                TPoint = tp;
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
