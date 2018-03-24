namespace SourceConsole.Templates.ReturningServiceTemplates
{
    partial class ServiceInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._ServiceInterface.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ServiceInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.ServiceInterface;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceInterfaceTemplate>();
            _DataModel._ServiceInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.ServiceInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ServiceInterface.FileName;
        }
    }
}
