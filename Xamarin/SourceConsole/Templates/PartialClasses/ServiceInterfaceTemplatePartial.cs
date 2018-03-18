namespace SourceConsole.Templates
{
    partial class ServiceInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

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
            return _DataModel.ServiceInterfaceName + "." + repo.GetSourceExtension(this);
        }
    }
}
