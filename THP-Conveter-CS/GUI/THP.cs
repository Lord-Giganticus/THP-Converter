using System;
using System.IO;
using System.Windows.Forms;
using FFmpeg.NET;
using System.Threading;

namespace THP_Conveter_CS.GUI
{
    public partial class THP : Form
    {
        private static event Notify Complete;

        public THP()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new()
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
            Complete += THP_Complete;
            SaveFileDialog save = new()
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
            var inputFile = new InputFile(Properties.Settings.Default.thp_video);
            var outFile = new OutputFile(outfile);
            if (!File.Exists(Properties.Settings.Default.ffmpeg_path)) {
                File.WriteAllBytes("ffmpeg.exe", Properties.Resources.ffmpeg);
            }
            var ffmpeg = new Engine(Properties.Settings.Default.ffmpeg_path);
            await ffmpeg.ConvertAsync(inputFile, outFile, CancellationToken.None);
            Complete?.Invoke();
            button2.Hide();
            File.Delete("ffmpeg.exe");
            return;
        }

        private void THP_Complete()
        {
            MessageBox.Show("Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private delegate void Notify();
    }
}
