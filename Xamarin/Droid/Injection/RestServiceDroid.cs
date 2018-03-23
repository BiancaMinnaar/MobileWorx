using System.Net;
using System.Threading.Tasks;
using BasePCL.Networking;
using CorePCL;
using HiRes.Droid.Injection;
using RestSharp;
using Xamarin.Forms;

[assembly: Dependency(typeof(RestServiceDroid))]
namespace HiRes.Droid.Injection
{
    public class RestRqst : RestRequest, INetworkRequest
    {
        public RestRqst(string urlExtention, Method httpMethodType)
            : base(urlExtention, httpMethodType)
        {
        }

        public static Method GetHttpMethod(BaseNetworkAccessEnum httpMethodType)
        {
            switch (httpMethodType)
            {
                default:
                    return Method.GET;
                case BaseNetworkAccessEnum.Post:
                    return Method.POST;
                case BaseNetworkAccessEnum.Put:
                    return Method.PUT;
            }
        }

        public void AddFile(string name, byte[] value, string fileName)
        {
            base.AddFile(name, value, fileName);
        }

        public new void AddHeader(string name, string value)
        {
            base.AddHeader(name, value);
        }

        public void AddJsonBody(BaseViewModel body)
        {
            base.AddJsonBody(body);
        }

        void INetworkRequest.AddParameter(string name, object value)
        {
            base.AddParameter(name, value);
        }
    }

    public class RestRspns : INetworkResponse
    {
        IRestResponse _RestResponse;
        public HttpStatusCode StatusCode => _RestResponse.StatusCode;
        public string StatusDescription => _RestResponse.StatusDescription;
        public string Content => _RestResponse.Content;
        public byte[] RawBytes => _RestResponse.RawBytes;

        public RestRspns(IRestResponse response)
        {
            _RestResponse = response;
        }
    }

    public class RestRspns<T> : RestRspns, INetworkResponse<T> where T : BaseViewModel
    {
        IRestResponse<T> _RestResponse;

        public RestRspns(IRestResponse<T> response)
            : base(response)
        {
            _RestResponse = response;
        }

        public T Data { get => _RestResponse.Data; set => _RestResponse.Data = value; }
    }

    public class RestServiceDroid : INetworkInteraction
    {
        public INetworkRequest GetNetworkRequest(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public INetworkRequest GetNetworkRequestForJson(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public async Task<INetworkResponse> ExecuteTaskAsync(INetworkRequest req)
        {
            var client = new RestClient(Constants.BASE_URL);
            var response = await client.ExecuteTaskAsync((IRestRequest)req);
            return new RestRspns(response);
        }

        public async Task<INetworkResponse<T>> ExecuteTaskAsync<T>(INetworkRequest req) where T : BaseViewModel
        {
            var client = new RestClient(Constants.BASE_URL);
            var response = await client.ExecuteTaskAsync<T>((IRestRequest)req);
            return new RestRspns<T>(response);
        }
    }
}
