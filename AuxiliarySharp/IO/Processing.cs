using Alphaleonis.Win32.Filesystem;
using Newtonsoft.Json;
using System.Text;

namespace AuxiliaryToolsSharp.IO
{
    public static class Processing
    {

        public static void Serialize<T>(string filename, T aimClass)
        {
            string json = JsonConvert.SerializeObject(aimClass, Formatting.Indented);
            WriteFile(filename, json);
        }
        public static T DeSerialize<T>(string filename)
        {
            string json = ReadFile(filename);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ReadFile(string filename)
        {
            string result = null;

            if (File.Exists(filename))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename, Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        public static void WriteFile(string filename, string content)
        {
            if (filename == null)
                return;

            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                Directory.CreateDirectory(Path.GetDirectoryName(filename));

            File.WriteAllText(filename, content, Encoding.UTF8);
        }

        public static void DeleteFile(string filename)
        {
            if (filename == null)
                return;

            if (File.Exists(filename))
                File.Delete(filename);
        }
    }
}
