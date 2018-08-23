using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AuxiliarySharp.IO
{
    public static class Drive
    {
        public enum Sigdn : uint
        {
            Normaldisplay = 0x00000000,
            Parentrelativeparsing = 0x80018001,
            Desktopabsoluteparsing = 0x80028000,
            Parentrelativeediting = 0x80031001,
            Desktopabsoluteediting = 0x8004c000,
            Filesyspath = 0x80058000,
            Url = 0x80068000,
            Parentrelativeforaddressbar = 0x8007c001,
            Parentrelative = 0x80080001
        }
        [DllImport("shell32.dll")]
        internal static extern uint SHGetNameFromIDList(IntPtr pidl, Sigdn sigdnName, [Out] out String ppszName);
        [DllImport("shell32.dll")]
        internal static extern uint SHParseDisplayName(string pszName, IntPtr zero, [Out] out IntPtr ppidl, uint sfgaoIn, [Out] out uint psfgaoOut);

        public static string GetDriveLabel(string driveName)
        {
            return (SHParseDisplayName(driveName, IntPtr.Zero, out IntPtr pidl, 0, out uint dummy) == 0
                && SHGetNameFromIDList(pidl, Sigdn.Normaldisplay, out string driveLabel) == 0
                && driveLabel != null) ? driveLabel : null;
        }
    }
}
