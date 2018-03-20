using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePCL
{
    public class BaseService<T>
        where T:BaseViewModel
    {
        protected Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> _NetworkInterface;

        public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
        {
            _NetworkInterface = networkInterface;
        }
    }

	public class BaseService
	{
		protected Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> _NetworkInterface;
        protected Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task> _NetworkWithBodyInterface;
        protected Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<BaseViewModel>> _NetworkWithReturnModel;

		public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
		{
			_NetworkInterface = networkInterface;
		}

        public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task> networkInterface)
        {
            _NetworkWithBodyInterface = networkInterface;
        }

        public BaseService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<BaseViewModel>> networkInterface)
        {
            _NetworkWithReturnModel = networkInterface;
        }
	}
}
