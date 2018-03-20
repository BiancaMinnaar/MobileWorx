namespace SourceConsole.Templates
{
    partial class RepositoryInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public RepositoryInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.RepositoryInterface;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryInterfaceTemplate>();
            _DataModel._RepositoryInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._RepositoryInterface.FileName;
        }

    }
}
