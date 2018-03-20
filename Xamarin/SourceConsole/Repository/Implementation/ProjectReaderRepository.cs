﻿using System.Xml;
using SourceConsole.Templates;

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
            _ProjectFile.Load(_Model.ProjectFileLocation);
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", "http://schemas.microsoft.com/developer/msbuild/2003");
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

        public bool InsertFileReferenceInProjectFile(TemplateDataModel model)
        {
            var namespaceURI = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager xnManager =
                new XmlNamespaceManager(_ProjectFile.NameTable);
            xnManager.AddNamespace("tu", namespaceURI);
            XmlNode xnRoot = _ProjectFile.DocumentElement;
            var allGroups = xnRoot.SelectNodes("//tu:ItemGroup", xnManager);
            var mainGroupNode = allGroups[0];
            var embededGroupNodel = allGroups[1];
            var viewElement = _ProjectFile.CreateElement("Compile", namespaceURI);
            viewElement.SetAttribute("Include", model._View.FullFileName);
            mainGroupNode.AppendChild(viewElement);
            _ProjectFile.Save(_Model.ProjectFileLocation);

            return false;
        }
    }
}
