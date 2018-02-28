using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using ResPublica.Base;
using ResPublica.Implementation.ViewModel;
using ResPublica.Interface.Service;

namespace ResPublica.Implementation.Service
{
    public class RegisterService : BaseService, IRegisterService
    {
        public RegisterService(Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task Register(RegisterViewModel model)
        {
            string requestURL = "/path/{Parameter}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, object>()
            {
                //{"Parameter", model.Property},
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }
    }
}
