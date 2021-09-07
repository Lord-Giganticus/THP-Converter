using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace THP_Converter_CS_CLI.Classes
{
    static class ProgramData
    {
        internal static DirectoryInfo ProgramDir => new(AppDomain.CurrentDomain.BaseDirectory);
    }
}
