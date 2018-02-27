using System;
namespace SourceConsole.Templates
{
    partial class ViewModelTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewModelTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
