using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    public enum SourceEnum
    {
        PBContentPage,
        RepositoryInterface,
        Repository,
        ServiceInterface,
        Service,
        ViewCodeBehind,
        View,
        ViewControllerInterface,
        ViewController,
        ViewModel
    }

    public class SourceFileMapRepository<T> : ISourceFileMapRepository<T>
        where T : ITemplate
    {
        IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());

        public SourceEnum GetSourceEnumFromTempate(T template)
        {
            return template.TemplateEnum;
        }

        public string GetSourceExtension(T template)
        {
            switch(template.TemplateEnum)
            {
                case SourceEnum.View:
                               return "xaml";
                default:
                    return "cs";
            }
        }

        public string GetSourcePath(T template)
        {
            switch(template.TemplateEnum)
            {
                case SourceEnum.PBContentPage:
                    return readerRepo.GetBaseFolderPath();
                case SourceEnum.Repository:
                    return readerRepo.GetRepositoryPath();
                case SourceEnum.RepositoryInterface:
                    return readerRepo.GetRepositoryInterfacePath();
                case SourceEnum.Service:
                    return readerRepo.GetServicePath();
                case SourceEnum.ServiceInterface:
                    return readerRepo.GetServiceInterfacePath();
                case SourceEnum.View:
                    return readerRepo.GetViewPath();
                case SourceEnum.ViewCodeBehind:
                    return readerRepo.GetViewCodeBehindPath();
                case SourceEnum.ViewController:
                    return readerRepo.GetViewControllerPath();
                case SourceEnum.ViewControllerInterface:
                    return readerRepo.GetViewControllerInterfacePath();
                case SourceEnum.ViewModel:
                    return readerRepo.GetViewModelPath();
                default:
                    throw new NotSupportedException("Your template isn't supported.");
            }
        }
    }
}
