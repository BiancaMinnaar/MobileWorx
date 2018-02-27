using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;

namespace ResPublica.Base
{
    public class BaseService
    {
        protected Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> _NetworkInterface;
        protected Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> _NetworkInterfaceWithTypedParameters;

        public BaseService(Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> networkInterface)
        {
            _NetworkInterface = networkInterface;
        }

		public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
		{
			_NetworkInterfaceWithTypedParameters = networkInterface;
		}
    }
}
