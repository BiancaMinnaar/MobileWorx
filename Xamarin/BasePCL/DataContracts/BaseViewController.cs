using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePCL
{
    public abstract class BaseViewController<T> 
        where T : BaseViewModel
    {
        public event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;

        public event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;

        public event EventHandler NetworkCallInitialised;
        public event EventHandler NetworkCallCompleted;

        protected BasePCL.Networking.RestService _RestService;
        public string _ResponseContent;
        public byte[] _RawBytes { get; set; }

        public T InputObject { get; set; }

        public BaseViewController()
        {
            _RestService = new BasePCL.Networking.RestService();
            _RestService.NetworkInteractionSucceeded += (sender, e) => NetworkInteractionSucceeded(sender, e);
            _RestService.NetworkInteractionFailed += (sender, e) => NetworkInteractionFailed(sender, e);
            _RestService.NetworkCallInitialised += (sender, e) => NetworkCallInitialised(sender, e);
            _RestService.NetworkCallCompleted += (sender, e) => NetworkCallCompleted(sender, e);
        }

        protected abstract string SerializeObject(T objectToSerialize);

		protected async Task ExecuteQueryWithObjectAndNetworkAccessAsync(
			string urlExtension, Dictionary<string, object> paramterCollection, BaseNetworkAccessEnum networkAccess = BaseNetworkAccessEnum.Get)
        {
            await _RestService.ExecuteNetworkRequestAsync(urlExtension, paramterCollection, networkAccess);
        }

		protected async Task ExecuteQueryWithTypedParametersAndNetworkAccessAsync(
			string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkAccess = BaseNetworkAccessEnum.Get)
		{
			await _RestService.ExecuteNetworkRequestAsync(urlExtension, paramterCollection, networkAccess);
		}

        protected async Task<R> ExecuteQueryWithReturnTypeAndNetworkAccessAsync<R>(
            string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseViewModel body, BaseNetworkAccessEnum networkAccess = BaseNetworkAccessEnum.Get)
            where R: BaseViewModel
        {
            return await _RestService.ExecuteNetworkRequestAsync<R>(urlExtension, paramterCollection, body, networkAccess);
        }
    }
}
