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
            repo.WriteTemplateToFile(new ViewModelTemplate(screenData));
            repo.WriteTemplateToFile(new ViewTemplate(screenData));
            repo.WriteTemplateToFile(new ViewCodeBehindTemplate(screenData));
            repo.WriteTemplateToFile(new ViewControllerInterfaceTemplate(screenData));
            repo.WriteTemplateToFile(new ViewControllerTemplate(screenData));
            repo.WriteTemplateToFile(new RepositoryInterfaceTemplate(screenData));
            repo.WriteTemplateToFile(new RepositoryTemplate(screenData));
            repo.WriteTemplateToFile(new ServiceInterfaceTemplate(screenData));
            repo.WriteTemplateToFile(new ServiceTemplate(screenData));

            readerRepo.InsertFileReferenceInProjectFile(screenData);
        }
    }
}
