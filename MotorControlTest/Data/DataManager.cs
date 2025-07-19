using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class DataManager
    {
        public Data.IniFile inifile;
        public Data.TeachingData teachingData;
        public Data.TaskWorkData taskWorkData;
        public DataManager()
        {
            inifile = new IniFile("Default.ini");
            teachingData = new TeachingData();
            taskWorkData = new TaskWorkData();
        }

        public static string GetDefaultValue(int axisCount, int index)
        {
            if (axisCount <= 0) return "";

            string[] zeros = new string[axisCount];
            for (int i = 0; i < axisCount; i++)
            {
                if(index == 0)
                {
                    zeros[i] = "0";
                }
                else
                {
                    zeros[i] = "0.0";
                }
                
            }
            return string.Join(",", zeros);
        }
    }
}
