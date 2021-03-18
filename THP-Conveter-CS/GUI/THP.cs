using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using FFmpeg.NET;

namespace THP_Conveter_CS.GUI
{
    public partial class THP : Form
    {
        public THP()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "thp file (*.thp)|*.thp|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                Multiselect = false,
                Title = "Select a thp video."
            };
            string thp_video = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                thp_video = open.FileName;
                button2.Show();
            }
            Properties.Settings.Default.thp_video = thp_video;
            Properties.Settings.Default.Save();
            return;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "mp4 file (*.mp4)|*.mp4|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Save the new mp4 file.",
                FileName = Path.GetFileNameWithoutExtension(Properties.Settings.Default.thp_video)
            };
            string outfile = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                outfile = save.FileName;
            }
            var inputFile = new MediaFile(Properties.Settings.Default.thp_video);
            var outFile = new MediaFile(outfile);
            if (!File.Exists(Properties.Settings.Default.ffmpeg_path)) {
                OpenFileDialog open = new OpenFileDialog
                {
                    Title = "Locate ffmpeg.exe",
                    Filter = "exe file (*.exe)|.exe|All files (*.*)|*.*",
                    FilterIndex = 2,
                    FileName = "ffmpeg.exe",
                    RestoreDirectory = true,
                    InitialDirectory = @"C:\Program Files (x86)",
                    Multiselect = false
                };
                MessageBox.Show("The program cannot locate a valid ffmpeg install! Press OK to search for it.","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.ffmpeg_path = open.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            var ffmpeg = new Engine(Properties.Settings.Default.ffmpeg_path);
            await ffmpeg.ConvertAsync(inputFile, outFile);
            MessageBox.Show("Complete!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            button2.Hide();
            return;
        }
    }
}
