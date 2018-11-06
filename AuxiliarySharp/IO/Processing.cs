﻿using Alphaleonis.Win32.Filesystem;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace AuxiliarySharp.IO
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
        public static IEnumerable<byte[]> ReadFileByChunk(string filename, int chunkSize = 1024 * 1024 * 100 /*100 Mb*/, int covering = 0)
        {
            long size = new System.IO.FileInfo(filename).Length;
            if (File.Exists(filename))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    int coveringSeek = -covering > 0 ? -covering : 0;
                    fs.Seek(coveringSeek, System.IO.SeekOrigin.Current);

                    byte[] buffer = new byte[chunkSize];
                    fs.Read(buffer, 0, chunkSize);

                    yield return buffer;
                }
            }
        }

        public static byte[] ReadFileChunk(string filename, int chunkSize = 1024 * 1024 * 100 /*100 Mb*/)
        {
            long size = new System.IO.FileInfo(filename).Length;
            if (File.Exists(filename))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    byte[] buffer = new byte[chunkSize];
                    fs.Read(buffer, 0, chunkSize);

                    return buffer;
                }
            }

            return null;
        }
        public static IEnumerable<string> ReadFileByChunkAsString(string filename, int chunkSize = 1024 * 1024 * 100 /*100 Mb*/, int covering = 0)
        {
            foreach (byte[] array in ReadFileByChunk(filename, chunkSize, covering))
            {
                yield return Encoding.Default.GetString(array);
            }
        }
        public static IEnumerable<string> ReadFileByLine(string filename)
        {
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadLines(filename))
                {
                    yield return line;
                }
            }
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
