# StringsSharp
Just a bunch of useful methods

# Method list
* Drive
  * string GetDriveLabel(string driveName)
* Folder
  * IEnumerable<string> GetKnownFolders()
  * string GetKnownFolder(KnownFolders type)
* General
  * string GetCurrentTime()
  * string GetCurrentDirectory()
  * void CopyToClipboard(object value)
  * string MakeRelative(string path)
  * void OpenDirectory(string filename)
  * string GetHumanReadableFileSize(string filepath)
  * string GetHumanReadableFileSize(long filesize)
  * bool CheckIfFileIsAccessible(string filepath)
* Processing
  * void Serialize<T>(string filename, T aimClass)
  * T DeSerialize<T>(string filename)
  * string ReadFile(string filename)
  * void WriteFile(string filename, string content)
  * void DeleteFile(string filename)
* ShellIcon
  * ImageSource GetShellIcon(string filePath)
