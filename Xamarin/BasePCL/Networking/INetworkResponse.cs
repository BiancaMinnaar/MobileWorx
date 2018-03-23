using System.Net;
using CorePCL;

namespace BasePCL.Networking
{
    public interface INetworkResponse
    {
        HttpStatusCode StatusCode { get; }
        string StatusDescription { get; }
        string Content { get; }
        byte[] RawBytes { get; }
    }

    public interface INetworkResponse<T> : INetworkResponse
        where T : BaseViewModel
    {
        T Data { get; set; }
    }
}
