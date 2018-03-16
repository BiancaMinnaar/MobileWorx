using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    public class GenerationReposetory : IGenerationReposetory
    {
        IFileService _FileService;
        IProjectReaderRepository _ProjectReader;

        public GenerationReposetory(IProjectReaderRepository projectReader, IFileService fileService)
        {
            _FileService = fileService;
            _ProjectReader = projectReader;
        }

        public TemplateDataModel GetDataModel(string screenName, string projectName)
        {
            return new TemplateDataModel(screenName, projectName);
        }

        public TemplateDataModel GetDataModel(Func<string> screenName)
        {
            return new TemplateDataModel(screenName(), _ProjectReader.GetProjectName());
        }

        public bool WriteTemplateToFile(string templateOutput, string fullFilePath)
        {
            return _FileService.WriteFileToDisk(fullFilePath, templateOutput);
        }
    }
}
