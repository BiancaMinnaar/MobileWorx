using System;
namespace SourceConsole.Templates
{
    partial class ServiceInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ServiceInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
