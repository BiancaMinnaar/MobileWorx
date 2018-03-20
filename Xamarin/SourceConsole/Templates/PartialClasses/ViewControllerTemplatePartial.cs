namespace SourceConsole.Templates
{
    partial class ViewControllerTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

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
            _DataModel._ViewController = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this)
            };
            return _DataModel._ViewController.FileName;
        }
    }
}
