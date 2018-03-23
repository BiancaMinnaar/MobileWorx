using System.Threading.Tasks;
using CorePCL;

namespace BasePCL.Networking
{
    public interface INetworkInteraction
    {
        INetworkRequest GetNetworkRequest(string urlExtention, BaseNetworkAccessEnum httpMethodType);
        INetworkRequest GetNetworkRequestForJson(string urlExtention, BaseNetworkAccessEnum httpMethodType);
        Task<INetworkResponse> ExecuteTaskAsync(INetworkRequest req);
        Task<INetworkResponse<T>> ExecuteTaskAsync<T>(INetworkRequest req) where T : BaseViewModel;
    }
}
