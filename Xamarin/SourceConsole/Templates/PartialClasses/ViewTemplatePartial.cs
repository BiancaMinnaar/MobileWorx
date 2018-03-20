namespace SourceConsole.Templates
{
    partial class ViewTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._View.FileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Xaml;

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
            _DataModel._View = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._View.FileName;
        }
    }
}
