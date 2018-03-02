using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;

namespace ResPublica.Base
{
	public class BaseService
	{
		protected Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> _NetworkInterface;

		public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
		{
			_NetworkInterface = networkInterface;
		}
	}
}
