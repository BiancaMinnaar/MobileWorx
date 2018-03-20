namespace SourceConsole.Templates.DataModel
{
    public class FileModel
    {
		public string CodeName { get; set; }
        public string Extension { get; set; }
        public string FileName { get { return CodeName + '.' + Extension; }}
    }
}
