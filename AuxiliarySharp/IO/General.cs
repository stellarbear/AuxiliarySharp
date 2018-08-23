using Alphaleonis.Win32.Filesystem;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace AuxiliarySharp.IO
{
    public static class General
    {
        public static string GetCurrentTime() => DateTime.Now.ToString("yyyyMMdd_HHmmss");
        public static string GetCurrentDirectory() => AppDomain.CurrentDomain.BaseDirectory;


        public static void CopyToClipboard(object value)
        {
            try
            {
                if (value != null)
                    Clipboard.SetDataObject(value);
            }
            catch { }
        }

        public static string MakeRelative(string path)
        {
            Uri fullPath = new Uri(path, UriKind.Absolute);
            Uri relRoot = new Uri(GetCurrentDirectory(), UriKind.Absolute);

            return Uri.UnescapeDataString(relRoot.MakeRelativeUri(fullPath).ToString()).Replace("/", "\\");
        }

        public static void OpenDirectory(string filename)
        {
            if (Directory.Exists(Path.GetDirectoryName(filename)))
                Process.Start("explorer.exe", "/select, \"" + filename + "\"");
        }

        public static string GetHumanReadableFileSize(string filepath)
        {
            if (CheckIfFileIsAccessible(filepath))
            {
                long fileSizeInBytes = (new FileInfo(filepath)).Length;

                return GetHumanReadableFileSize(fileSizeInBytes);
            }

            return default(string);
        }
        public static string GetHumanReadableFileSize(long filesize)
        {
            long fileSizeInBytes = filesize;

            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

            if (fileSizeInBytes == 0)
                return "0\t" + suf[0];

            long bytes = Math.Abs(fileSizeInBytes);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return String.Join("\t", (Math.Sign(fileSizeInBytes) * num).ToString(CultureInfo.InvariantCulture), suf[place]);
        }

        public static bool CheckIfFileIsAccessible(string filepath)
        {
            try
            {
                using (System.IO.FileStream FileStream =
                    File.Open(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
