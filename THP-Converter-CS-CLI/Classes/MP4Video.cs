using System;
using System.IO;
using System.Diagnostics;
using static THP_Converter_CS_CLI.Properties.Resources;

namespace THP_Converter_CS_CLI.Classes
{
    class MP4Video
    {
        public MP4Video(ushort width, ushort height, FileInfo inFile, FileInfo outFile, double rate = 29.97, bool useAudio = false)
        {
            Width = width;
            Height = height;
            Rate = rate > 1.0 ? (rate < 59.94 ? rate : 59.94) : 1.0;
            UseAudio = useAudio;
            InFile = inFile.Extension is ".mp4" ? inFile : throw new Exception("The inFile paramater must be a mp4 file.");
            OutFile = outFile.Extension is ".thp" ? outFile : new($"{outFile.FullName[0..outFile.FullName.LastIndexOf(".")]}.thp");
        }

        protected MP4Video()
        {

        }

        protected ushort Width { get; set; }
        
        protected ushort Height { get; set; }

        protected double Rate { get; set; } = 29.97;

        protected bool UseAudio { get; set; }

        protected FileInfo InFile { get; set; }

        protected FileInfo OutFile { get; set; }

        public void Convert()
        {
            Directory.SetCurrentDirectory(ProgramData.ProgramDir.FullName);
            File.WriteAllBytes("ffmpeg.exe", ffmpeg);
            File.Move(InFile.FullName, "video.mp4");
            Directory.CreateDirectory("temp");
            Process.Start(startInfo: new()
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/c ffmpeg.exe -i video.mp4 -r {Rate} -vf scale={Width}:{Height} -qscale:v 2 temp\\frame%05d.jpg"
            }).WaitForExit();
            File.Delete("ffmpeg.exe");
            if (UseAudio)
            {
                File.WriteAllBytes("mplayer.exe", mplayer);
                Process.Start(startInfo: new()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c mplayer.exe -vo null -ao pcm:file=temp.wav video.mp4"
                }).WaitForExit();
                File.Delete("mplayer.exe");
            }
            File.WriteAllBytes("THPConv.exe", THPConv);
            File.WriteAllBytes("dsptool.dll", dsptool);
            Process.Start(startInfo: new()
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/c thpconv.exe -j temp/*.jpg -r {Rate}{(UseAudio ? " -s temp.wav" : "")} -d output.thp"
            }).WaitForExit();
            File.Move("output.thp", OutFile.FullName);
            Console.WriteLine($"Converted {InFile.Name} to {OutFile.Name}");
        }
    }
}
