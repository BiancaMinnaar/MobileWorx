using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Service
{
	public class LoginService : BaseService, ILoginService
	{
		public LoginService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
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

			parameters["username"] = new ParameterTypedValue(model.UserName);
			parameters["password"] = new ParameterTypedValue(model.Password);

			var deviceId = Plugin.DeviceInfo.CrossDeviceInfo.Current.GenerateAppId(true, "RSL");
			parameters["device"] = new ParameterTypedValue(deviceId);
			parameters["token_type"] = new ParameterTypedValue("app");

			await _NetworkInterface(requestURL, parameters, httpMethod);
		}
	}
}
