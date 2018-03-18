namespace SourceConsole
{
    public class FileService : IFileService
    {
        public string ReadFromFile(string FullFilePath)
        {
            return System.IO.File.ReadAllText(FullFilePath);
        }

        public bool WriteFileToDisk(string fullFilePath, string content)
        {
            System.IO.File.WriteAllText(fullFilePath, content);
            return System.IO.File.Exists(fullFilePath);
        }
    }
}
