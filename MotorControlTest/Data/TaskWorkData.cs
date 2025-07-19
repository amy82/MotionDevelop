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


        public TaskWorkPoint LeftSocketTaskWorkArr;
        public TaskWorkPoint RightSocketTaskWorkArr;


        public TaskWorkData()
        {
            int i = 0;
            LeftSocketTaskWorkArr = new TaskWorkPoint();
            RightSocketTaskWorkArr = new TaskWorkPoint();
            LeftSocketTaskWorkArr.Name = "LEFT_SOCKET_STATE";
            RightSocketTaskWorkArr.Name = "RIGHT_SOCKET_STATE";

            LeftSocketTaskWorkArr.State = new int[Machine.SocketMachine.socketCount];
            RightSocketTaskWorkArr.State = new int[Machine.SocketMachine.socketCount];

            for (i = 0; i < LeftSocketTaskWorkArr.State.Length; i++)
            {
                LeftSocketTaskWorkArr.State[i] = 0;
            }
            for (i = 0; i < RightSocketTaskWorkArr.State.Length; i++)
            {
                RightSocketTaskWorkArr.State[i] = 0;
            }
        }
        public void testSave()
        {
            Save(GlobalClass.motionManager.socketMachine.taskWorkPath, LeftSocketTaskWorkArr);
            Save(GlobalClass.motionManager.socketMachine.taskWorkPath, RightSocketTaskWorkArr);
        }
        public void testLoad()
        {
            Load(GlobalClass.motionManager.socketMachine.taskWorkPath, ref LeftSocketTaskWorkArr);
            Load(GlobalClass.motionManager.socketMachine.taskWorkPath, ref RightSocketTaskWorkArr);
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

                //for (i = 0; i < TPoint.Length; i++)
                //{
                //    string section = TPoint[i].Name;

                //    GlobalClass.dataManager.inifile.Write(section, "State", string.Join(",", TPoint[i].State));
                //}
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
