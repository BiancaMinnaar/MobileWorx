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
            string screenName;
            string projectName;

            if (args.Length > 0)
            {
                screenName = args[0];
                projectName = args[1];
            }
            else
            {
                Console.Write("Screen Name:");
                screenName = Console.ReadLine();
                Console.Write("Project Name:");
                projectName = Console.ReadLine();
            }
            var screenData = new TemplateDataModel(screenName, projectName);

			generateClass(screenData, new ViewModelTemplate(screenData), screenData.ViewModelName + ".cs");
            generateClass(screenData, new ViewTemplate(screenData), screenData.ViewName + ".xaml");
            generateClass(screenData, new ViewCodeBehindTemplate(screenData), screenData.ViewName + ".cs");
			generateClass(screenData, new ViewControllerInterfaceTemplate(screenData), screenData.ViewControllerInterfaceName + ".cs");
            generateClass(screenData, new ViewControllerTemplate(screenData), screenData.ViewControllerName + ".cs");
			generateClass(screenData, new RepositoryInterfaceTemplate(screenData), screenData.RepositoryInterfaceName + ".cs");
            generateClass(screenData, new RepositoryTemplate(screenData), screenData.RepositoryName + ".cs");
            generateClass(screenData, new ServiceInterfaceTemplate(screenData), screenData.ServiceInterfaceName + ".cs");
            generateClass(screenData, new ServiceTemplate(screenData), screenData.ServiceName + ".cs");
        }
    }
}
