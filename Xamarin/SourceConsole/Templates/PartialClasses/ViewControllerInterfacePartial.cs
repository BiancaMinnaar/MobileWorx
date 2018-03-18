namespace SourceConsole.Templates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewControllerInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewControllerInterface;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerInterfaceTemplate>();
            return _DataModel.RepositoryName + repo.GetSourceExtension(this);
        }
    }
}
