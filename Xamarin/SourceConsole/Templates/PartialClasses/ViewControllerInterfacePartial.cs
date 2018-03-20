namespace SourceConsole.Templates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

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
            _DataModel._ViewControllerInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.ViewControllerInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewControllerInterface.FileName;
        }
    }
}
