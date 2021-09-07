using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using FFmpeg.NET;
using static THP_Converter_CS_CLI.Properties.Resources;

namespace THP_Converter_CS_CLI.Classes
{
    class THP
    {
        protected FileInfo InFile { get; set; }

        protected FileInfo OutFile { get; set; }

        public THP(FileInfo infile, FileInfo outfile)
        {
            InFile = infile.Extension is ".thp"? infile : throw new Exception("The infile paramater requires a thp video.");
            OutFile = outfile.Extension is ".mp4" ? outfile : throw new Exception("The outfile paramater requires a mp4 video.");
        }

        public async Task<MediaFile> Convert()
        {
            Directory.SetCurrentDirectory(ProgramData.ProgramDir.FullName);
            await File.WriteAllBytesAsync("ffmpeg.exe", ffmpeg);
            var engine = new Engine("ffmpeg.exe");
            var infile = new InputFile(InFile);
            var outfile = new OutputFile(OutFile);
            var r = await engine.ConvertAsync(infile, outfile);
            File.Delete("ffmpeg.exe");
            return r;
        }
    }
}
