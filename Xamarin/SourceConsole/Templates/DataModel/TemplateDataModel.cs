﻿using System;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates
{
    public class TemplateDataModel : CorePCL.BaseViewModel
    {
        public string ProjectName { get; set; }
		public string EventName { get; set; }
        public FileModel _ViewModel { get; set; }
		public string ViewModelName { 
            get { return _ViewModel.CodeName; } 
            set { _ViewModel = new FileModel() { CodeName = value }; }
        }
        public FileModel _View { get; set; }
        public string ViewName {
            get { return _View.CodeName; }
            set { _View = new FileModel() { CodeName = value }; }
        }
        public string ViewCodeBehindName
        {
            get { return _View.CodeName; }
            set { _View = new FileModel() { CodeName = value }; }
        }
        public FileModel _ViewController { get; set; }
        public string ViewControllerName {
            get { return _ViewController.CodeName; }
            set { _ViewController = new FileModel() { CodeName = value }; }
        }
        public FileModel _ViewControllerInterface { get; set; }
        public string ViewControllerInterfaceName {
            get { return _ViewControllerInterface.CodeName; }
            set { _ViewControllerInterface = new FileModel() { CodeName = value }; }
        }
        public FileModel _Repository { get; set; }
        public string RepositoryName {
            get { return _Repository.CodeName; }
            set { _Repository = new FileModel() { CodeName = value }; }
        }
        public FileModel _RepositoryInterface { get; set; }
        public string RepositoryInterfaceName {
            get { return _RepositoryInterface.CodeName; }
            set { _RepositoryInterface = new FileModel() { CodeName = value }; }
        }
        public FileModel _Service { get; set; }
        public string ServiceName {
            get { return _Service.CodeName; }
            set { _Service = new FileModel() { CodeName = value }; }
        }
        public FileModel _ServiceInterface { get; set; }
        public string ServiceInterfaceName {
            get { return _ServiceInterface.CodeName; }
            set { _ServiceInterface = new FileModel() { CodeName = value }; }
        }

        public TemplateDataModel(string screenName, string projectName)
        {
            ProjectName = projectName;
            EventName = screenName;
			setData();
        }

        public TemplateDataModel(Func<string> inputProjectName , Func<string> inputScreenName)
        {
            ProjectName = inputProjectName();
            EventName = inputScreenName();
            setData();
        }

        void setData()
        {
            ViewModelName = EventName + "ViewModel";
            ViewName = EventName + "View";
            ViewControllerName = EventName + "ViewController";
            ViewControllerInterfaceName = "I" + ViewControllerName;
            RepositoryName = EventName + "Repository";
            RepositoryInterfaceName = "I" + RepositoryName;
            ServiceName = EventName + "Service";
            ServiceInterfaceName = "I" + ServiceName;
        }
    }
}
