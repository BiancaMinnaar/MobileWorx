namespace SourceConsole.Templates
{
    partial class RepositoryInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public RepositoryInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.RepositoryInterface;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryInterfaceTemplate>();
            return _DataModel.RepositoryInterfaceName + repo.GetSourceExtension(this);
        }
    }
}
