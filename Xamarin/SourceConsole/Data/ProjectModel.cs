namespace SourceConsole
{
    public class ProjectModel : Data.GenericTemplateModel
    {
        public string RepositoryInterfacePath {get;set;}
        public string RepositoryPath {get;set;}
        public string ServiceInterfacePath {get;set;}
        public string ServicePath {get;set;}
        public string ViewCodeBehindPath {get;set;}
        public string ViewControllerInterfacePath {get;set;}
        public string ViewControllerPath {get;set;}
        public string ViewModelPath {get;set;}
        public string ViewPath {get;set;}
    }
}
