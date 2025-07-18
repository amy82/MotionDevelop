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

        public DataManager()
        {
            inifile = new IniFile("Default.ini");
        }
    }
}
