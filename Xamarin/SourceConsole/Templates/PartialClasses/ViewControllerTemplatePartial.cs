namespace SourceConsole.Templates
{
    partial class ViewControllerTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewControllerTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewController;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerTemplate>();
            return _DataModel.RepositoryName + repo.GetSourceExtension(this);
        }
    }
}
