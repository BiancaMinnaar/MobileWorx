namespace SourceConsole.Templates
{
    partial class RepositoryTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public RepositoryTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.Repository;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryTemplate>();
            return _DataModel.RepositoryName + "." + repo.GetSourceExtension(this);
        }
    }
}
