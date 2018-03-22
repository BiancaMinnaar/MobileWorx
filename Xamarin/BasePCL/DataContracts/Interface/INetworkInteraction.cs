using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;

namespace BasePCL.DataContracts.Interface
{
    public interface INetworkInteraction
    {
		event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;
        event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;
		event EventHandler NetworkCallInitialised;
		event EventHandler NetworkCallCompleted;

        Task ExecuteNetworkRequestAsync(string urlExtension, Dictionary<string, object> paramterCollection, BaseNetworkAccessEnum networkAccess = BaseNetworkAccessEnum.Get);
        Task ExecuteNetworkRequestAsync(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkAccess = BaseNetworkAccessEnum.Get);
        Task<T> ExecuteNetworkRequestAsync<T>(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseViewModel body, BaseNetworkAccessEnum networkCallType) where T:BaseViewModel;
    }
}
