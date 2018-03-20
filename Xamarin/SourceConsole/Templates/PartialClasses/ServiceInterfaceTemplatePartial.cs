namespace SourceConsole.Templates
{
    partial class ServiceInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public ServiceInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ServiceInterface;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceInterfaceTemplate>();
            _DataModel._ServiceInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ServiceInterface.FileName;
        }
    }
}
