namespace SourceConsole.Templates.NormalTemplates
{
    partial class RepositoryInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;
        public TemplateDataModel GetDataModel => _DataModel;
        public string FullProjectFileName => _DataModel._RepositoryInterface.FullProjectFileName;
        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;
		public SourceEnum TemplateEnum => SourceEnum.RepositoryInterface;

        public RepositoryInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
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
