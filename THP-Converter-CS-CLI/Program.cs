using System;
using System.IO;
using System.Collections.Generic;
using THP_Converter_CS_CLI.Classes;

namespace THP_Converter_CS_CLI
{
    static class Program
    {
        static double Rate { get; set; } = 29.97;

        static ushort Width { get; set; } = 0;

        static ushort Height { get; set; } = 0;

        static bool UseAudio { get; set; } = false;

        static FileInfo OutFile { get; set; }

        static FileInfo InFile { get; set; }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
                switch (args[i])
                {
                    case "-i":
                    case "--in":
                        if (i + 1 > args.Length) throw new Exception("The paramerters were malformed.");
                        if (!File.Exists(args[i + 1])) throw new FileNotFoundException("Input file must exist.");
                        InFile = new(args[i + 1]);
                        i++;
                        break;
                    case "-r":
                    case "--rate":
                        if (i + 1 > args.Length) throw new Exception("The parameters were malformed.");
                        Rate = double.Parse(args[i + 1]);
                        i++;
                        break;
                    case "-wi":
                    case "--width":
                        if (i + 1 > args.Length) throw new Exception("The parameters were malformed.");
                        Width = ushort.Parse(args[i + 1]);
                        i++;
                        break;
                    case "-he":
                    case "--height":
                        if (i + 1 > args.Length) throw new Exception("The parameters were malformed.");
                        Height = ushort.Parse(args[i + 1]);
                        i++;
                        break;
                    case "-a":
                    case "--audio":
                        if (i + 1 > args.Length)
                            throw new Exception("The parameters were malformed.");
                        UseAudio = true;
                        i++;
                        break;
                    case "-h":
                    case "--help":
                        ShowHelp();
                        break;
                    case "-o":
                    case "--out":
                        if (i + 1 > args.Length)
                            throw new Exception("The parameters were malformed.");
                        OutFile = new(args[i + 1]);
                        i++;
                        break;
                }
            if (InFile.Extension is ".thp")
            {
                if (OutFile.Extension is not ".mp4") throw new Exception("Outfile needs to be a mp4 if the Inputfile is a thp.");
                new THP(InFile, OutFile).Convert().GetAwaiter().GetResult();
                Console.WriteLine($"Converted {InFile.Name} to {OutFile.Name}.");
            } else if (InFile.Extension is ".mp4")
            {
                if (OutFile.Extension is not ".thp") throw new Exception("Outfile needs to be a thp if the Inputfile is a mp4.");
                new MP4Video(Width is 0 ? (ushort)640 : Width, Height is 0 ? (ushort)368 : Height, InFile, OutFile, Rate is 0 ? 29.97 : Rate, UseAudio).Convert();
            }
        }

        static void ShowHelp()
        {
            string[] lines =
            {
                "THP-Converter-CS-CLI",
                "Created by Lord-Giganticus",
                "Command Usage:",
                "-i/--in (The input file to use)",
                "-r/--rate (The frame rate of a new THP Video. Defaults to 29.97)",
                "-wi/--width (The width of a new THP Video. Defauts to 640)",
                "-he/--height (The height of a new THP Video. Defaults to 368)",
                "-a/--audio (Use audio when making a new THP Video. Defaults to False)",
                "-h/--help (Shows this)",
                "-o/--out (The file to write to)"
            };
            Console.WriteLine(string.Join("\n", lines));
        }
    }
}
