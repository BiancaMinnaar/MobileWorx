using System.Xml;

namespace SourceConsole
{
    public class ProjectReaderRepository : IProjectReaderRepository
    {
		IFileService _FileService;
        ProjectModel _Model;
        XmlDocument _ProjectFile;

        public ProjectReaderRepository(IFileService fileService)
        {
			_FileService = fileService;
            _Model = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<ProjectModel>(_FileService.ReadFromFile("../../Data/Project.Config"), _Model);
            _ProjectFile = new XmlDocument();
            _ProjectFile.LoadXml(_FileService.ReadFromFile(_Model.ProjectFileLocation));
        }

        public string GetProjectFileLocation()
        {
            return _Model.ProjectFileLocation;
        }

        public string GetProjectName()
        {
            return _Model.ProjectName;
        }

        public string GetRepositoryInterfacePath()
        {
            return _Model.RepositoryInterfacePath;
        }

        public string GetRepositoryPath()
        {
            return _Model.RepositoryPath;
        }

        public string GetServiceInterfacePath()
        {
            return _Model.ServiceInterfacePath;
        }

        public string GetServicePath()
        {
            return _Model.ServicePath;
        }

        public string GetViewCodeBehindPath()
        {
            return _Model.ViewCodeBehindPath;
        }

        public string GetViewControllerInterfacePath()
        {
            return _Model.ViewControllerInterfacePath;
        }

        public string GetViewControllerPath()
        {
            return _Model.ViewControllerPath;
        }

        public string GetViewModelPath()
        {
            return _Model.ViewModelPath;
        }

        public string GetViewPath()
        {
            return _Model.ViewPath;
        }

        public bool InsertFileReferenceInProjectFile()
        {
            var test = _ProjectFile.SelectNodes(_Model.FileListXPath);
            return false;
        }
    }
}
