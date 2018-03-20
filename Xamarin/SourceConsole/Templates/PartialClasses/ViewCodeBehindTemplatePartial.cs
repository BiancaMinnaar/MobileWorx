namespace SourceConsole.Templates
{
    partial class ViewCodeBehindTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public ViewCodeBehindTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewCodeBehind;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewCodeBehindTemplate>();
            _DataModel._ViewCodeBehind = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ViewCodeBehind.FileName;
        }
    }
}
