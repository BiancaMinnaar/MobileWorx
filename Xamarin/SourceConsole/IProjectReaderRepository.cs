namespace SourceConsole
{
    public interface IProjectReaderRepository
    {
        string GetProjectName();
        string GetProjectFileLocation();
        string GetRepositoryInterfacePath();
        string GetRepositoryPath();
        string GetServiceInterfacePath();
        string GetServicePath();
        string GetViewCodeBehindPath();
        string GetViewControllerInterfacePath();
        string GetViewControllerPath();
        string GetViewModelPath();
        string GetViewPath();
        //bool InsertFileReferenceInProjectFile();
    }
}
