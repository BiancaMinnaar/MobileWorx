namespace SourceConsole
{
    public interface IFileService
    {
        bool WriteFileToDisk(string fullFilePath, string content);
        string ReadFromFile(string FullFilePath);
    }
}
