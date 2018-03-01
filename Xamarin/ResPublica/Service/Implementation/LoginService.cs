using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using ResPublica.Base;
using ResPublica.Implementation.ViewModel;
using ResPublica.Interface.Service;

namespace ResPublica.Implementation.Service
{
	public class LoginService : BaseService, ILoginService
	{
		public LoginService(Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> networkInterface)
			: base(networkInterface)
		{
		}

		public async Task Login(LoginViewModel model)
		{
			string requestURL = "http://sm2.respublica.co.za/API/app/AppAPI/Login";
			var httpMethod = BaseNetworkAccessEnum.Post;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"X-API-TOKEN", new ParameterTypedValue() {
                        ParameterValue="boguskey",
                        ParameterType=ParameterTypeEnum.HeaderParameter
                    }
                }
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
		}
	}
}
