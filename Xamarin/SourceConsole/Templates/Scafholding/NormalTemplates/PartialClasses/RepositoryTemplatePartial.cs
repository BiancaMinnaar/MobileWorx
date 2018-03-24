namespace SourceConsole.Templates.NormalTemplates
{
    partial class RepositoryTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._Repository.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public RepositoryTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.Repository;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<RepositoryTemplate>();
            _DataModel._Repository = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._Repository.FileName;
        }
    }
}
