namespace SourceConsole.Templates
{
    partial class ViewModelTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ViewModel.FileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

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
            _DataModel._ViewModel = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewModelName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewModel.FileName;
        }
    }
}
