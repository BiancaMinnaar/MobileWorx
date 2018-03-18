namespace SourceConsole.Templates
{
    partial class ViewCodeBehindTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewCodeBehindTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewCodeBehind;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewCodeBehindTemplate>();
            return _DataModel.RepositoryName + repo.GetSourceExtension(this);
        }
    }
}
