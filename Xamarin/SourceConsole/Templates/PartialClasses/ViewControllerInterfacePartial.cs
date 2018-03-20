﻿namespace SourceConsole.Templates
{
    partial class ViewControllerInterfaceTemplate : ITemplate
    {
        TemplateDataModel _DataModel;

        public TemplateDataModel GetDataModel => _DataModel;

        public ViewControllerInterfaceTemplate(TemplateDataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public SourceEnum TemplateEnum()
        {
            return SourceEnum.ViewControllerInterface;
        }

        public string GetFileName()
        {
            var repo = new SourceFileMapRepository<ViewControllerInterfaceTemplate>();
            _DataModel._ViewControllerInterface = new DataModel.FileModel()
            {
                CodeName = _DataModel.RepositoryInterfaceName,
                Extension = repo.GetSourceExtension(this)
            };
            return _DataModel._ViewControllerInterface.FileName;
        }
    }
}
