using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    public enum SourceEnum
    {
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
            return template.TemplateEnum();
        }

        public string GetSourceExtension(T template)
        {
            switch(template.TemplateEnum())
            {
                case SourceEnum.View:
                               return "xaml";
                default:
                    return "cs";
            }
        }

        public string GetSourcePath(T template)
        {
            switch(template.TemplateEnum())
            {
                case SourceEnum.Repository:
                    return readerRepo.GetRepositoryPath();
                default:
                    throw new NotSupportedException("Your template isn't supported.");
            }
        }
    }
}
