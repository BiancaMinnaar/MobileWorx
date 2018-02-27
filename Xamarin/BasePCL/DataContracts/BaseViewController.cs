using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasePCL.DataContracts.Interface;
using Xamarin.Forms;

namespace CorePCL
{
    public abstract class BaseViewController<T> 
        where T : BaseViewModel
    {
        public event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;

        public event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;

        public event EventHandler NetworkCallInitialised;
        public event EventHandler NetworkCallCompleted;

        protected INetworkInteraction _RestService;
        public string _ResponseContent;
        public byte[] _RawBytes { get; set; }

        public T InputObject { get; set; }

      

        public BaseViewController()
        {
            _RestService = DependencyService.Get<INetworkInteraction>();

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
    }
}
