using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.Data
{
    public class IniFile
    {
        public string Path { get; set; }

        public IniFile(string path)
        {
            this.Path = path;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, temp, 255, Path);
            return temp.ToString();
        }

        public bool Exists()
        {
            return System.IO.File.Exists(Path);
        }
    }
}

# region [사용예제]
/*
private void Form1_Load(object sender, EventArgs e)
{
    string iniPath = System.IO.Path.Combine(Application.StartupPath, "config.ini");
    ini = new IniFile(iniPath);

    // 불러오기 예시
    string teachX = ini.Read("TeachData", "X", "0");
    string teachY = ini.Read("TeachData", "Y", "0");

    textBoxX.Text = teachX;
    textBoxY.Text = teachY;
}
private void btnSave_Click(object sender, EventArgs e)
{
    // 저장하기 예시
    ini.Write("TeachData", "X", textBoxX.Text);
    ini.Write("TeachData", "Y", textBoxY.Text);

    
}
*/
# endregion
