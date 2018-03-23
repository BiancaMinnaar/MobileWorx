using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;
using HiRes.ViewModel;

namespace HiRes.Implementation.Service
{
    public class LoginService<T> : BaseService<T>, ILoginService<T>
        where T : BaseViewModel
	{
        public LoginService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
			: base(networkInterface)
		{
		}

        public async Task<T> Login(LoginViewModel model)
		{
			string requestURL = "login";
			var httpMethod = BaseNetworkAccessEnum.Post;
			var userModel = new UserModel()
            {
                username = model.Username,
                password = model.Password
            };

            return await _NetworkInterface(requestURL, null, userModel, httpMethod);
		}
	}
}
