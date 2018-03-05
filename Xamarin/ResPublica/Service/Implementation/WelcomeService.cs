using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Service
{
    public class WelcomeService : BaseService, IWelcomeService
    {
        public WelcomeService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task Welcome(WelcomeViewModel model)
        {
            string requestURL = "/path/{Parameter}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                //{"Parameter", model.Property},
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }
    }
}
