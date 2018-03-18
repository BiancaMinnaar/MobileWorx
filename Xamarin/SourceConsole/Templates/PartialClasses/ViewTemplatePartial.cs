namespace SourceConsole.Templates
{
    partial class ViewTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.View;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewTemplate>();
            return _DataModel.ViewName + "." + repo.GetSourceExtension(this);
        }
    }
}
