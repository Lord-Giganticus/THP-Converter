using System;
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
            label2.Hide();
            button2.Hide();
            textBox1.Hide();
            label3.Hide();
            UseAudioCheckBox.Hide();
            VideoSizeComboBox.Hide();
            VideoSizeComboBox.SelectedIndex = 0;
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
                label2.Show();
                button2.Show();
                textBox1.Show();
                label3.Show();
                VideoSizeComboBox.Show();
                UseAudioCheckBox.Show();
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
            File.Delete(outfile);
            string inputFile = Properties.Settings.Default.mp4_video;
            File.WriteAllBytes("ffmpeg.exe", Properties.Resources.ffmpeg);
            Classes.Manager manager = new();
            Classes.Manager.ExtractResource("THPConv.exe", Properties.Resources.THPConv);
            Classes.Manager.ExtractResource("dsptool.dll", Properties.Resources.dsptool);
            string scaleParameter = "";
            if ((string)VideoSizeComboBox.SelectedItem != "Original")
            {
                scaleParameter = $" -vf scale={((string)VideoSizeComboBox.SelectedItem)[0..((string)VideoSizeComboBox.SelectedItem).IndexOf('x')]}:"
                    + ((string)VideoSizeComboBox.SelectedItem)[(((string)VideoSizeComboBox.SelectedItem).IndexOf('x') + 1)..];
            }
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
                    Arguments = $"/c ffmpeg.exe -i video.mp4 -r {rate}{scaleParameter} -qscale:v 2 temp\\frame%05d.jpg"
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            if (UseAudioCheckBox.Checked)
            {
                using var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c ffmpeg.exe -i video.mp4 -acodec pcm_s16le -ac 2 -ar 32000 temp.wav"
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
                    Arguments = $"/c thpconv.exe -j temp/*.jpg -r {rate}{(UseAudioCheckBox.Checked ? " -s temp.wav" : "")} -d output.thp"
                };
                process.Start();
                process.WaitForExit();
            }
            File.Move("output.thp", outfile, true);
            Directory.SetCurrentDirectory(Classes.Copier.AssemblyDirectory);
            Environment.CurrentDirectory = Classes.Copier.AssemblyDirectory;
            Directory.Delete("temp", true);
            File.Delete("video.mp4");
            if (UseAudioCheckBox.Checked)
                File.Delete("temp.wav");
            File.Delete("THPConv.exe");
            File.Delete("dsptool.dll");
            File.Delete("ffmpeg.exe");
            Complete?.Invoke();
            label1.Hide();
            textBox1.Hide();
            button2.Hide();
            label3.Hide();
            VideoSizeComboBox.Hide();
            UseAudioCheckBox.Hide();
            return;
        }

        private void MP4_Complete()
        {
            MessageBox.Show("Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private delegate void Notify();
    }
}
