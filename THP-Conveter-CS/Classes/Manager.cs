using System.IO;

namespace THP_Conveter_CS.Classes
{
    class Manager
    {
        public void ExtractResource(string name, byte[] array)
        {
            File.WriteAllBytes(name, array);
        }
    }
}
