using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.ViewModel;
using Xamarin.Forms;

namespace HiRes.Interface.Repository
{
    public interface IMasterRepository
    {
        MasterModel DataSorce { get; set; }
        void SetRootView(Page rootView);
        Page GetRootView();
        Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }
        Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<BaseViewModel>> NetworkInterfaceWithReturn { get; set; }


        //Navigation
        void PushHomeView();
        void PushRegister();
		void PushSandbox();
        void PushWelcome();
        //Logic
        //debug
        void DumpJson<T>(string heading, T objectToDump);

		//Off-Line
	}
}
