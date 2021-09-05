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
using System.Diagnostics;

namespace THP_Conveter_CS.GUI
{
    public partial class MP4 : Form
    {
        private static event Notify Complete;

        public MP4()
        {
            InitializeComponent();
            label1.Hide();
            button2.Hide();
            textBox1.Hide();
            label3.Hide();
            VideoSizeComboBox.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new()
            {
                Title = "Search for a mp4 file",
                Filter = "mp4 file (*.mp4)|*.mp4|All files (*.*)|*.*",
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
                label3.Show();
                VideoSizeComboBox.Show();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Complete += MP4_Complete;
            string rate = Properties.Settings.Default.frame_rate;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                rate = textBox1.Text;
                double rate1 = double.Parse(rate);
                if (rate1 < 1.0)
                {
                    rate = "1.0";
                } else if (rate1 > 59.94)
                {
                    rate = "59.94";
                }
            }
            SaveFileDialog save = new()
            {
                Filter = "thp file (*.thp)|*.thp|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Save the new thp file.",
                FileName = Path.GetFileNameWithoutExtension(Properties.Settings.Default.mp4_video)
            };
            string outfile = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                outfile = save.FileName;
            }
            else if (save.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string[] lines =
            {
                ""
            };
            File.WriteAllLines(outfile, lines);
            var name = Path.GetFileName(outfile);
            File.Delete(outfile);
            string inputFile = Properties.Settings.Default.mp4_video;
            File.WriteAllBytes("ffmpeg.exe", Properties.Resources.ffmpeg);
            File.WriteAllBytes("mplayer.exe", Properties.Resources.mplayer);
            Classes.Manager manager = new();
            manager.ExtractResource("THPConv.exe", Properties.Resources.THPConv);
            manager.ExtractResource("dsptool.dll", Properties.Resources.dsptool);
            string width = (((string)VideoSizeComboBox.SelectedItem) ?? VideoSizeComboBox.Text)[0..(((string)VideoSizeComboBox.SelectedItem) ?? VideoSizeComboBox.Text).IndexOf('x')],
                height = (((string)VideoSizeComboBox.SelectedItem) ?? VideoSizeComboBox.Text)[(((string)VideoSizeComboBox.SelectedItem ?? VideoSizeComboBox.Text).IndexOf('x') + 1)..];
            Directory.CreateDirectory("temp");
            File.Copy(inputFile, "video.mp4");
            using (Process process = new())
            {
                ProcessStartInfo startInfo = new()
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/c ffmpeg.exe -i video.mp4 -r {rate} -vf scale={width}:{height} temp\\frame%03d.jpg"
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c mplayer.exe -ao pcm:file=temp.wav video.mp4"
                };
                process.Start();
                process.WaitForExit();
            }
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/c thpconv.exe -j temp/*.jpg -r {rate} -s temp.wav -d {name}"
                };
                process.Start();
                process.WaitForExit();
            }
            File.Move(name, outfile, true);
            Directory.SetCurrentDirectory(Classes.Copier.AssemblyDirectory);
            Environment.CurrentDirectory = Classes.Copier.AssemblyDirectory;
            Directory.Delete("temp", true);
            File.Delete("video.mp4");
            File.Delete("temp.wav");
            File.Delete("THPConv.exe");
            File.Delete("dsptool.dll");
            File.Delete("ffmpeg.exe");
            File.Delete("mplayer.exe");
            Complete?.Invoke();
            label1.Hide();
            textBox1.Hide();
            button2.Hide();
            label3.Hide();
            VideoSizeComboBox.Hide();
            return;
        }

        private void MP4_Complete()
        {
            MessageBox.Show("Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private delegate void Notify();
    }
}
