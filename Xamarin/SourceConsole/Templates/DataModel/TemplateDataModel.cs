using System;
namespace SourceConsole.Templates
{
    public class TemplateDataModel : CorePCL.BaseViewModel
    {
        public string ProjectName { get; set; }
		public string EventName { get; set; }
		public string ViewModelName { get; set; }
        public string ViewName { get; set; }
        public string ViewControllerName { get; set; }
        public string ViewControllerInterfaceName { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryInterfaceName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceInterfaceName { get; set; }

        public TemplateDataModel(string screenName, string projectName)
        {
            ProjectName = projectName;
            EventName = screenName;
			ViewModelName = screenName + "ViewModel";
            ViewName = screenName + "View";
            ViewControllerName = screenName + "ViewController";
            ViewControllerInterfaceName = "I" + ViewControllerName;
            RepositoryName = screenName + "Repository";
            RepositoryInterfaceName = "I" + RepositoryName;
            ServiceName = screenName + "Service";
            ServiceInterfaceName = "I" + ServiceName;
        }
    }
}
