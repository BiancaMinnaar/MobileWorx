using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using ResPublica.ViewModel;
using Xamarin.Forms;

namespace ResPublica.Interface.Repository
{
    public interface IMasterRepository
    {
        MasterModel DataSorce { get; set; }
        void SetRootView(Page rootView);
        Page GetRootView();
        Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }

        //Navigation
        void PushHomeView();
        void PushRegister();
        //Logic
        //debug
        void DumpJson<T>(string heading, T objectToDump);

        //Off-Line
    }
}
