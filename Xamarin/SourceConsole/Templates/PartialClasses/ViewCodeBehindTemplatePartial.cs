using System;
namespace SourceConsole.Templates
{
    partial class ViewCodeBehindTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewCodeBehindTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
