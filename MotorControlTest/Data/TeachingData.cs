using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorControlTest.Data
{

    public class TeachingData
    {
        public TeachingPoint[] TransferTeachingArr;
        public TeachingPoint[] SocketTeachingArr;
        public TeachingPoint[] MagazineTeachingArr;
        

        public TeachingData()
        {
            TransferTeachingArr = new TeachingPoint[Data.TransferTeachInfo.eteachName.Length];
            SocketTeachingArr = new TeachingPoint[Data.SocketTeachInfo.eteachName.Length];
            MagazineTeachingArr = new TeachingPoint[Data.MagazineTeachInfo.eteachName.Length];
        }
        public void testLoad()
        {
            TeachingLoad(GlobalClass.motionManager.transferMachine.teachingPath, Data.TransferTeachInfo.eteachName, TransferTeachingArr, GlobalClass.motionManager.transferMachine.MotorCnt);
            TeachingLoad(GlobalClass.motionManager.socketMachine.teachingPath, Data.SocketTeachInfo.eteachName, SocketTeachingArr, GlobalClass.motionManager.socketMachine.MotorCnt);
            TeachingLoad(GlobalClass.motionManager.magazineMachine.teachingPath, Data.MagazineTeachInfo.eteachName, MagazineTeachingArr, GlobalClass.motionManager.magazineMachine.MotorCnt);
        }
        public bool TeachingLoad(string filename, string[] keyArr, TeachingPoint[] TPoint, int axisCount)
        {
            try
            {
                int i = 0;
                int j = 0;
                string iniPath = System.IO.Path.Combine(Application.StartupPath, filename);
                GlobalClass.dataManager.inifile.Path = iniPath;

                string defaultValue = DataManager.GetDefaultValue(axisCount, 1);

                for (i = 0; i < keyArr.Length; i++)
                {
                    string name = keyArr[i];
                    string section = $"{name}";
                    string posStr = GlobalClass.dataManager.inifile.Read(section, "Pos", defaultValue);


                    string[] posTokens = posStr.Split(',');

                    TeachingPoint tp = new TeachingPoint();
                    tp.Name = name;
                    tp.Pos = new double[axisCount];
                    for (j = 0; j < axisCount; j++)
                    {
                        tp.Pos[j] = double.Parse(posTokens[j]);
                    }
                    ///tp.Pos = (double[])pos.Clone(); //배열 자체를 복사!

                    TPoint[i] = tp;


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
        public void testSave()
        {
            TeachingSave(GlobalClass.motionManager.transferMachine.teachingPath, TransferTeachingArr);
            TeachingSave(GlobalClass.motionManager.socketMachine.teachingPath, SocketTeachingArr);
            TeachingSave(GlobalClass.motionManager.magazineMachine.teachingPath, MagazineTeachingArr);
        }


        public bool TeachingSave(string filename, TeachingPoint[] TPoint)
        {
            try
            {
                int i = 0;
                string iniPath = System.IO.Path.Combine(Application.StartupPath, filename);
                GlobalClass.dataManager.inifile.Path = iniPath;

                for (i = 0; i < TPoint.Length; i++)
                {
                    string section = TPoint[i].Name;

                    GlobalClass.dataManager.inifile.Write(section, "Pos", string.Join(",", TPoint[i].Pos));
                }
                //ini.Write("Teaching_WAIT_POS", "Pos", string.Join(",", new[] { "10", "20", "30" }));
            }
            catch (Exception ex)
            {
                // 로그 출력 (필요하면 로그 파일로도 가능)
                Console.WriteLine("Teaching 저장 중 오류 발생: " + ex.Message);

                // 사용자 메시지
                MessageBox.Show("Teaching 저장 실패:\n" + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; // 저장 실패
            }

            return true;
        }
        

        

        
        public bool Save(string iniPath)
        {
            var ini = new IniFile(iniPath);

            // 기본 축 설정 저장
            ini.Write("Motion", "Speed", string.Join(",", new[] { "201", "200", "50" }));
            ini.Write("Motion", "Accel", string.Join(",", new[] { "1.1", "2.1", "3" }));
            ini.Write("Motion", "Decel", string.Join(",", new[] { "0.2", "0.2", "0.2" }));
            ini.Write("Motion", "Resolution", string.Join(",", new[] { "2000", "2500", "2000" }));

            // 티칭 포인트 저장
            ini.Write("Teaching_WAIT_POS", "Pos", string.Join(",", new[] { "10", "20", "30" }));
            ini.Write("Teaching_LEFT_TRAY_BCR_POS", "Pos", string.Join(",", new[] { "100.001", "200", "50" }));
            ini.Write("Teaching_RIGHT_TRAY_BCR_POS", "Pos", string.Join(",", new[] { "100.001", "200", "50" }));
            return true;
        }
        

        public bool ___Load(string filename)
        {
            int i = 0;
            string iniPath = System.IO.Path.Combine(Application.StartupPath, filename);// "teaching.ini");
            GlobalClass.dataManager.inifile.Path = iniPath;


            string[] Teachingnames = { "WAIT_POS", "LEFT_TRAY_BCR_POS", "RIGHT_TRAY_BCR_POS" };


            int axisCount = 3;
            string defaultValue = DataManager.GetDefaultValue(axisCount, 1);

            double[] speed = new double[axisCount];
            string[] posTokens = GlobalClass.dataManager.inifile.Read("Motion", "Speed", "0,0,0").Split(',');

            for (i = 0; i < speed.Length; i++)
            {
                speed[i] = double.Parse(posTokens[i].ToString());
            }
            for (i = 0; i < Teachingnames.Length; i++)
            {
                string name = Teachingnames[i];
                string section = $"{name}";
                string posStr = GlobalClass.dataManager.inifile.Read(section, "Pos", defaultValue);// "0,0,0");


                string[] posTokens2 = posStr.Split(',');
                double[] pos = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    pos[j] = double.Parse(posTokens2[j]);
                }

                TeachingPoint tp = new TeachingPoint();
                tp.Name = name;
                tp.Pos = pos;

                TransferTeachingArr[i] = tp;
            }
            return true;
        }

        
    }
}
