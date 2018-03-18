namespace SourceConsole.Templates
{
    partial class ServiceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

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
            return _DataModel.ServiceName + "." + repo.GetSourceExtension(this);
        }
    }
}
