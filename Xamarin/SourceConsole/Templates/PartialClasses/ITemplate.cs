using System;
namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        TemplateDataModel GetDataModel { get; }
        string TransformText();
        SourceEnum TemplateEnum();
        string GetFileName();
    }
}
