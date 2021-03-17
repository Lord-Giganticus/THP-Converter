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
    public partial class MP4 : Form
    {
        public MP4()
        {
            InitializeComponent();
            label1.Hide();
            button2.Hide();
            textBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Search for a mp4 file",
                Filter = "mp4 file (*.mp4)|.mp4|All files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = Directory.GetCurrentDirectory(),
                Multiselect = false
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.mp4_video = open.FileName;
                Properties.Settings.Default.Save();
                label1.Show();
                button2.Show();
                textBox1.Show();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rate = Properties.Settings.Default.frame_rate;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                rate = textBox1.Text;
            }
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "thp file (*.thp)|*.thp|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Save the new thp file."
            };
            string outfile = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                outfile = save.FileName;
            }
            string inputFile = Properties.Settings.Default.mp4_video;
            if (!File.Exists(Properties.Settings.Default.ffmpeg_path))
            {
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
                MessageBox.Show("The program cannot locate a valid ffmpeg install! Press OK to search for it.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.ffmpeg_path = open.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
