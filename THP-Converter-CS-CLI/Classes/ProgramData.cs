using System;
using System.IO;

namespace THP_Converter_CS_CLI.Classes
{
    static class ProgramData
    {
        internal static DirectoryInfo ProgramDir => new(AppDomain.CurrentDomain.BaseDirectory);
    }
}
