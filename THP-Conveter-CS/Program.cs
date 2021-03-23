using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THP_Conveter_CS
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings.Default.thp_video = "";
            Properties.Settings.Default.mp4_video = "";
            Properties.Settings.Default.Save();
            Classes.Manager manager = new Classes.Manager();
            manager.ExtractResource("ffmpeg.exe",Properties.Resources.ffmpeg);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
