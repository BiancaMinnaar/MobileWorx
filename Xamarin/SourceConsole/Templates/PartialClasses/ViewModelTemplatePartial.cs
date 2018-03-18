namespace SourceConsole.Templates
{
    partial class ViewModelTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewModelTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewModel;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewModelTemplate>();
            return _DataModel.ViewModelName + "." + repo.GetSourceExtension(this);
        }
    }
}
