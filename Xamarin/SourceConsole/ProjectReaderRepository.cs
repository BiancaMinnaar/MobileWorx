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

        public string GetProjectFileLocation()
        {
            return model.ProjectFileLocation;
        }

        public string GetProjectName()
        {
            return model.ProjectName;
        }

        public string GetRepositoryInterfacePath()
        {
            return model.RepositoryInterfacePath;
        }

        public string GetRepositoryPath()
        {
            return model.RepositoryPath;
        }

        public string GetServiceInterfacePath()
        {
            return model.ServiceInterfacePath;
        }

        public string GetServicePath()
        {
            return model.ServicePath;
        }

        public string GetViewCodeBehindPath()
        {
            return model.ViewCodeBehindPath;
        }

        public string GetViewControllerInterfacePath()
        {
            return model.ViewControllerInterfacePath;
        }

        public string GetViewControllerPath()
        {
            return model.ViewControllerPath;
        }

        public string GetViewModelPath()
        {
            return model.ViewModelPath;
        }

        public string GetViewPath()
        {
            return model.ViewPath;
        }
    }
}
