# StringsSharp
Just a bunch of useful methods

# Method list
string GetDriveLabel(string driveName)

IEnumerable<string> GetKnownFolders()
string GetKnownFolder(KnownFolders type)

string GetCurrentTime()
string GetCurrentDirectory()

void CopyToClipboard(object value)
string MakeRelative(string path)
void OpenDirectory(string filename)
string GetHumanReadableFileSize(string filepath)
string GetHumanReadableFileSize(long filesize)
bool CheckIfFileIsAccessible(string filepath)
void Serialize<T>(string filename, T aimClass)
T DeSerialize<T>(string filename)
string ReadFile(string filename)
void WriteFile(string filename, string content)
void DeleteFile(string filename)
ImageSource GetShellIcon(string filePath)