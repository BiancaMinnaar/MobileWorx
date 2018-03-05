using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Service
{
    public class WelcomeOneService : BaseService, IWelcomeOneService
    {
        public WelcomeOneService(Func<string, Dictionary<string, ParameterTypedValue>, object, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task WelcomeOne(WelcomeOneViewModel model)
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
