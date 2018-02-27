namespace SourceConsole.Templates
{
    partial class ServiceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ServiceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
