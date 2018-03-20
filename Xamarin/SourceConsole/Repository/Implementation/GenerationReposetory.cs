using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    public class GenerationReposetory : IGenerationReposetory
    {
        IFileService _FileService;
        IProjectReaderRepository _ProjectReader;
        TemplateDataModel _Model;

        public GenerationReposetory(IProjectReaderRepository projectReader, IFileService fileService)
        {
            _FileService = fileService;
            _ProjectReader = projectReader;
        }

        public TemplateDataModel GetDataModel(string screenName, string projectName)
        {
            _Model = new TemplateDataModel(screenName, projectName);
            return _Model;
        }

        public TemplateDataModel GetDataModel(Func<string> screenName)
        {
            _Model = new TemplateDataModel(screenName(), _ProjectReader.GetProjectName());
            return _Model;
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
            var hasWritten = _FileService.WriteFileToDisk(fullName, templateOutput);
            if (template.TemplateType == 0)
            {
				_ProjectReader.InsertFileReferenceInProjectFile(template.FullProjectFileName);
            }
            else
            {
                _ProjectReader.InsertXamlFileReferenceInProjectFile(template.FullProjectFileName, template.GetFileName().Split('.')[0] + ".cs");
                _ProjectReader.InsertXamlEmbededResourceInProjectFile(template.FullProjectFileName);
            }

            return true;
        }
    }
}
