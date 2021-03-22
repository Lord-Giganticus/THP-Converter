using System.IO;
using THP_Conveter_CS.Properties;

namespace THP_Conveter_CS.Classes
{
    class Manager
    {
        public void ExtractTHPConv(string name)
        { 
            File.WriteAllBytes(name, Resources.THPConv);
        }
        public void Extractdsptool(string name)
        {
            File.WriteAllBytes(name, Resources.dsptool);
        }
    }
}
