using System;
using System.Collections.Generic;
using Mono.Options;

namespace THP_Converter_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool show_help = false;
            string in_file;
            string out_file;
            int rate;
            var p = new OptionSet()
            {
                { "h|help",  "show this message and exit", v => show_help = v != null },
                { "in|in-file", "the input file to convert.", v => in_file = v },
                { "out|out-file", "the output file generated at the end.", v => out_file = v },
                { "r|rate", "the frame rate of a thp video. (ONLY FOR MAKING THP FILES)", v => rate = int.Parse(v)}
            };
            List<string> extra;
            try {
                extra = p.Parse (args);
            }
            catch (OptionException e) {
                Console.Write("THP-Converter: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `THP-Converter --help' for more information.");
                return;
            }
            if (show_help || extra.Count < 1)
            {
                ShowHelp(p);
                return;
            }
        }
        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: THP-Conveter [OPTIONS]");
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
