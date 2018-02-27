using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CorePCL
{
    public interface IRestService
    {
        Task Get(string urlExtension);
        Task Post(string urlExtension, HttpContent content);
        Task Put(string urlExtension, HttpContent content);
        event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;
        event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;
        event EventHandler NetworkCallInitialised;
        event EventHandler NetworkCallCompleted;
    }
}
