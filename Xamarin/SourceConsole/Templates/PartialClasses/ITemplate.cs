namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        PartialClasses.TemplateEnum TemplateType { get; }
        TemplateDataModel GetDataModel { get; }
		string FullProjectFileName { get; }
        string TransformText();
        SourceEnum TemplateEnum();
        string GetFileName();
    }
}
