using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory repo = new GenerationReposetory(readerRepo, new FileService());
            var screenData = repo.GetDataModel(() =>
                {
                    Console.Write("Screen Name:");
                    return Console.ReadLine();
            });
            var viewModel = new ViewModelTemplate(screenData);
            repo.WriteTemplateToFile(viewModel);
            readerRepo.InsertFileReferenceInProjectFile(viewModel.FullProjectFileName);

            ViewTemplate template = new ViewTemplate(screenData);
            repo.WriteTemplateToFile(template);
            ViewCodeBehindTemplate template1 = new ViewCodeBehindTemplate(screenData);
            repo.WriteTemplateToFile(template1);
            readerRepo.InsertXamlFileReferenceInProjectFile(screenData._ViewCodeBehind.FullProjectFileName, screenData._View.FileName);
            readerRepo.InsertXamlEmbededResourceInProjectFile(screenData._View.FullProjectFileName);

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
