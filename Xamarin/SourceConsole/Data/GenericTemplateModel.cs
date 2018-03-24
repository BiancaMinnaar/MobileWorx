using CorePCL;

namespace SourceConsole.Data
{
    public class GenericTemplateModel : BaseViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectFileLocation { get; set; }
        public string FileListXPath { get; set; }
        public string BaseFolderPath { get; set; }
    }
}
