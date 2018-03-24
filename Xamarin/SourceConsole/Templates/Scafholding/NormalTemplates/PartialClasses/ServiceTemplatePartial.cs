namespace SourceConsole.Templates.NormalTemplates
{
    partial class ServiceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public string FullProjectFileName => _DataModel._Service.FullProjectFileName;

        public PartialClasses.TemplateEnum TemplateType => PartialClasses.TemplateEnum.Normal;

        public ServiceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum => SourceEnum.Service;

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ServiceTemplate>();
            _DataModel._Service = new DataModel.FileModel()
            {
                CodeName = _DataModel.ServiceName,
                Extension = repo.GetSourceExtension(this),
                ProjectFilePath = repo.GetSourcePath(this)
            };
            return _DataModel._Service.FileName;
        }
    }
}
