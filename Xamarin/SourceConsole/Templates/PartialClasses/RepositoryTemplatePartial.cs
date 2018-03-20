namespace SourceConsole.Templates
{
    partial class RepositoryTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public RepositoryTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.Repository;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryTemplate>();
            _DataModel._Repository = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this)
            };
            return _DataModel._Repository.FileName;
        }
    }
}
