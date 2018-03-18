using System;
using SourceConsole.Templates;

namespace SourceConsole
{
    public interface IGenerationReposetory
    {
        TemplateDataModel GetDataModel(string screenName, string projectName);
        TemplateDataModel GetDataModel(Func<string> screenName);
        bool WriteTemplateToFile(string fullFilePath, string templateOutput);
        bool WriteTemplateToFile<T>(T template) where T:ITemplate;
    }
}
