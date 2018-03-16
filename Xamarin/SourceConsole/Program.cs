using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IGenerationReposetory repo = new GenerationReposetory(new ProjectReaderRepository(new FileService()), new FileService());
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            var screenData = repo.GetDataModel(() =>
                {
                    Console.Write("Screen Name:");
                    return Console.ReadLine();
            });
            repo.WriteTemplateToFile(new ViewModelTemplate(screenData).TransformText(), 
                                     readerRepo.GetViewModelPath() + screenData.ViewModelName + ".cs");
            repo.WriteTemplateToFile(new ViewTemplate(screenData).TransformText(),
                                     readerRepo.GetViewPath() + screenData.ViewName + ".xaml");
            repo.WriteTemplateToFile(new ViewCodeBehindTemplate(screenData).TransformText(), 
                                     readerRepo.GetViewCodeBehindPath() + screenData.ViewName + ".cs");
            repo.WriteTemplateToFile(new ViewControllerInterfaceTemplate(screenData).TransformText(), 
                                     readerRepo.GetViewControllerInterfacePath() + screenData.ViewControllerInterfaceName + ".cs");
            repo.WriteTemplateToFile(new ViewControllerTemplate(screenData).TransformText(), 
                                     readerRepo.GetViewControllerPath() + screenData.ViewControllerName + ".cs");
            repo.WriteTemplateToFile(new RepositoryInterfaceTemplate(screenData).TransformText(), 
                                     readerRepo.GetRepositoryInterfacePath() + screenData.RepositoryInterfaceName + ".cs");
            repo.WriteTemplateToFile(new RepositoryTemplate(screenData).TransformText(), 
                                     readerRepo.GetRepositoryPath() + screenData.RepositoryName + ".cs");
            repo.WriteTemplateToFile(new ServiceInterfaceTemplate(screenData).TransformText(), 
                                     readerRepo.GetServiceInterfacePath() + screenData.ServiceInterfaceName + ".cs");
            repo.WriteTemplateToFile(new ServiceTemplate(screenData).TransformText(), 
                                     readerRepo.GetServicePath() + screenData.ServiceName + ".cs");
        }
    }
}
