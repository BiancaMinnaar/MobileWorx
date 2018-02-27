namespace SourceConsole.Templates
{
    partial class ViewControllerTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewControllerTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
