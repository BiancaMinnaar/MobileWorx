namespace SourceConsole.Templates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public ViewControllerInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }
    }
}
