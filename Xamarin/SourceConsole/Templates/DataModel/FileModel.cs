namespace SourceConsole.Templates.DataModel
{
    public class FileModel
    {
		public string CodeName { get; set; }
        public string Extension { get; set; }
        public string FileName { get { return CodeName + '.' + Extension; }}
        public string ProjectFilePath { get; set; }
        public string FullProjectFileName 
        { 
            get 
            { 
                var cleanPath = ProjectFilePath.Replace('/', '\\').Split(new string[] {"..\\"}, System.StringSplitOptions.None);
                return cleanPath[cleanPath.Length-1] + FileName; 
            }
        }
    }
}
