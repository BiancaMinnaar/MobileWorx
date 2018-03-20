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
            readerRepo.InsertFileReferenceInProjectFile(screenData._ViewModel.FullProjectFileName);
            repo.WriteTemplateToFile(new ViewTemplate(screenData));
            //readerRepo.InsertFileReferenceInProjectFile(screenData._View.FullProjectFileName);
            repo.WriteTemplateToFile(new ViewCodeBehindTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._ViewCodeBehind.FullProjectFileName);
            repo.WriteTemplateToFile(new ViewControllerInterfaceTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._ViewControllerInterface.FullProjectFileName);
            repo.WriteTemplateToFile(new ViewControllerTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._ViewController.FullProjectFileName);
            repo.WriteTemplateToFile(new RepositoryInterfaceTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._RepositoryInterface.FullProjectFileName);
            repo.WriteTemplateToFile(new RepositoryTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._Repository.FullProjectFileName);
            repo.WriteTemplateToFile(new ServiceInterfaceTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._ServiceInterface.FullProjectFileName);
            repo.WriteTemplateToFile(new ServiceTemplate(screenData));
            readerRepo.InsertFileReferenceInProjectFile(screenData._Service.FullProjectFileName);


        }
    }
}
