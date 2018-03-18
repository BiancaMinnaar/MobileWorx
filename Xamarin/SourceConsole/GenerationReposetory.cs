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

        public bool WriteTemplateToFile(string fullFilePath, string templateOutput)
        {
            return _FileService.WriteFileToDisk(fullFilePath, templateOutput);
        }

        public bool WriteTemplateToFile<T>(T template) where T : ITemplate
        {
            var templateOutput = template.TransformText();
            var templateEnum = template.TemplateEnum();
            var fullName = new SourceFileMapRepository<T>().GetSourcePath(template) + template.GetFileName();
            return _FileService.WriteFileToDisk(fullName, templateOutput);
        }
    }
}
