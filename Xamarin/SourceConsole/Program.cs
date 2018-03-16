using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    class MainClass
    {
        static void generateClass(TemplateDataModel screenData, ITemplate template, string fileName)
        {
            string templateOutput = template.TransformText();
            System.IO.File.WriteAllText(fileName, templateOutput);
        }

        public static void Main(string[] args)
        {
            IGenerationReposetory repo = new GenerationReposetory(new ProjectReaderRepository(new FileService()), new FileService());
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            var screenData = repo.GetDataModel(() =>
                {
                    Console.Write("Screen Name:");
                    return Console.ReadLine();
            });
            repo.WriteTemplateToFile(new ViewModelTemplate(screenData).TransformText(), screenData.ViewModelName + ".cs");
            repo.WriteTemplateToFile(new ViewTemplate(screenData).TransformText(), screenData.ViewName + ".xaml");
            repo.WriteTemplateToFile(new ViewCodeBehindTemplate(screenData).TransformText(), screenData.ViewName + ".cs");
            repo.WriteTemplateToFile(new ViewControllerInterfaceTemplate(screenData).TransformText(), screenData.ViewControllerInterfaceName + ".cs");
            repo.WriteTemplateToFile(new ViewControllerTemplate(screenData).TransformText(), screenData.ViewControllerName + ".cs");
            repo.WriteTemplateToFile(new RepositoryInterfaceTemplate(screenData).TransformText(), screenData.RepositoryInterfaceName + ".cs");
            repo.WriteTemplateToFile(new RepositoryTemplate(screenData).TransformText(), screenData.RepositoryName + ".cs");
            repo.WriteTemplateToFile(new ServiceInterfaceTemplate(screenData).TransformText(), screenData.ServiceInterfaceName + ".cs");
            repo.WriteTemplateToFile(new ServiceTemplate(screenData).TransformText(), screenData.ServiceName + ".cs");
        }
    }
}
