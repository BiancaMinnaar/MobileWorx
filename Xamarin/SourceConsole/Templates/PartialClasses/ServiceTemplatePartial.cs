namespace SourceConsole.Templates
{
    partial class ServiceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public ServiceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.Service;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceTemplate>();
            _DataModel._Service = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this)
            };
            return _DataModel._Service.FileName;
        }
    }
}
