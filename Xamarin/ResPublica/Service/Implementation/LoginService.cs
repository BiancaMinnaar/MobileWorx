using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;
using HiRes.ViewModel;
using HiRes.ViewModel.ReturnModel;

namespace HiRes.Implementation.Service
{
	public class LoginService<T> : BaseService, ILoginService<T>
	{
        Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> _NetworkInterface;

        public LoginService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
			: base(networkInterface)
		{
            _NetworkInterface = networkInterface;
		}

        public async Task<T> Login(LoginViewModel model)
		{
			string requestURL = "/Login";
			var httpMethod = BaseNetworkAccessEnum.Post;
			var userModel = new UserModel()
            {
                username = model.UserName,
                password = model.Password,
                device = "12",
                token_type = "app",
                X_API_KEY = "boguskey_rsl"
            };

            return await _NetworkInterface(requestURL, null, userModel, httpMethod);
		}
	}
}
