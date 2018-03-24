namespace SourceConsole.Templates.NormalTemplates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ViewControllerInterface.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ViewControllerInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ViewControllerInterface;

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
