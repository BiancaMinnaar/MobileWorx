using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CorePCL;

namespace HiRes.Base
{
	public class BaseService
	{
		protected Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> _NetworkInterface;
        protected Func<string, Dictionary<string, ParameterTypedValue>, object, BaseNetworkAccessEnum, Task> _NetworkWithBodyInterface;

		public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
		{
			_NetworkInterface = networkInterface;
		}

        public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, object, BaseNetworkAccessEnum, Task> networkInterface)
        {
            _NetworkWithBodyInterface = networkInterface;
        }
	}
}
