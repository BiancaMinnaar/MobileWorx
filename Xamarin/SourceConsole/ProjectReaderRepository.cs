using System;
namespace SourceConsole
{
    public class ProjectReaderRepository : IProjectReaderRepository
    {
        ProjectModel model;
        IFileService _FileService;

        public ProjectReaderRepository(IFileService fileService)
        {
            model = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<ProjectModel>(fileService.ReadFromFile("../../Data/Project.Config"), model);
            _FileService = fileService;
        }

        public string GetProjectName()
        {
            return model.ProjectName;
        }
    }
}
