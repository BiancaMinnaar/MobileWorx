using SourceConsole.Templates.PartialClasses;

namespace SourceConsole.Templates.Framework
{
    partial class ProjectBaseContentPageTemplate : ITemplate
    {
        TemplateDataModel _DataModel;
		public TemplateDataModel GetDataModel => _DataModel;
        public TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;
        public SourceEnum TemplateEnum => SourceEnum.PBContentPage;
        public string FullProjectFileName => _DataModel._RepositoryInterface.FullProjectFileName;

        public ProjectBaseContentPageTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ProjectBaseContentPageTemplate>();
            _DataModel._ProjectBaseContentPage = new DataModel.FileModel()
            {
                CodeName = _DataModel.ProjectBaseContentPageName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._ProjectBaseContentPage.FileName;
        }
    }
}
