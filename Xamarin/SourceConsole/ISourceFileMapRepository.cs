using SourceConsole.Templates;

namespace SourceConsole
{
    public interface ISourceFileMapRepository<T> where T: ITemplate
    {
        SourceEnum GetSourceEnumFromTempate(T template);
        string GetSourceExtension(T template);
        string GetSourcePath(T template);
    }
}
