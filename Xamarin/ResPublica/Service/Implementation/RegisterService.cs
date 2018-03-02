using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Service
{
    public class RegisterService : BaseService, IRegisterService
    {
        public RegisterService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task Register(RegisterViewModel model)
        {
            string requestURL = "http://sm2.respublica.co.za/API/app/AppAPI/Register";
            var httpMethod = BaseNetworkAccessEnum.Get;
			var parameters = new Dictionary<string, ParameterTypedValue>()
			{
				{"X-API-TOKEN", new ParameterTypedValue() {
						ParameterValue="boguskey",
						ParameterType=ParameterTypeEnum.HeaderParameter
					}
				}
			};
			await _NetworkInterface(requestURL, parameters, httpMethod);
        }
    }
}
