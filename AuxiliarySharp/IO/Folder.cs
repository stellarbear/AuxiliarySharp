using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AuxiliarySharp.IO
{
    public static class Folder
    {
        public enum KnownFolders
        {
            Contacts,
            Desktop,
            Documents,
            Downloads,
            Favorites,
            Links,
            Music,
            Pictures,
            SavedGames,
            SavedSearches,
            Videos
        }
        private enum KnownFoldersFlags : uint
        {
            SimpleIdList = 0x00000100,
            NotParentRelative = 0x00000200,
            DefaultPath = 0x00000400,
            Init = 0x00000800,
            NoAlias = 0x00001000,
            DontUnexpand = 0x00002000,
            DontVerify = 0x00004000,
            Create = 0x00008000,
            NoAppcontainerRedirection = 0x00010000,
            AliasOnly = 0x80000000
        }
        private static Dictionary<KnownFolders, string> _knownFolderList = new Dictionary<KnownFolders, string>()
        {
            { KnownFolders.Contacts,     "{56784854-C6CB-462B-8169-88E350ACB882}" },
            { KnownFolders.Desktop,      "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}" },
            { KnownFolders.Documents,    "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}" },
            { KnownFolders.Downloads,    "{374DE290-123F-4565-9164-39C4925E467B}" },
            { KnownFolders.Favorites,    "{1777F761-68AD-4D8A-87BD-30B759FA33DD}" },
            { KnownFolders.Links,        "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}" },
            { KnownFolders.Music,        "{4BD8D571-6D19-48D3-BE97-422220080E43}" },
            { KnownFolders.Pictures,     "{33E28130-4E1E-4676-835A-98395C3BC3BB}" },
            { KnownFolders.SavedGames,   "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}" },
            { KnownFolders.SavedSearches,"{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}" },
            { KnownFolders.Videos,       "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}" }
        };
        [DllImport("shell32.dll")]
        private static extern int SHGetKnownFoldersPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        public static string GetKnownFolder(KnownFolders type)
        {
            int result = SHGetKnownFoldersPath(
                new Guid(_knownFolderList[type]),
                (uint)KnownFoldersFlags.DontVerify,
                new IntPtr(0),
                out IntPtr outPath);

            return result < 0 ? null : Marshal.PtrToStringUni(outPath);
        }
        public static IEnumerable<string> GetKnownFolders()
        {
            return _knownFolderList.Keys.Select(x => GetKnownFolder(x));
        }
    }
}
