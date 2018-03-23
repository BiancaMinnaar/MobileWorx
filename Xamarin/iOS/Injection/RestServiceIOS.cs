using System;
using System.Net;
using System.Threading.Tasks;
using BasePCL.Networking;
using CorePCL;
using HiRes.iOS.Injection;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;

[assembly: Dependency(typeof(RestServiceIOS))]
namespace HiRes.iOS.Injection
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

        public RestRspns(IRestResponse response)
        {
            _RestResponse = response;
        }

        public HttpStatusCode StatusCode => _RestResponse.StatusCode;

        public string StatusDescription => _RestResponse.StatusDescription;

        public string Content => _RestResponse.Content;

        public byte[] RawBytes => _RestResponse.RawBytes;
    }

    public class RestRspns<T> : RestRspns, INetworkResponse<T> where T : BaseViewModel
    {
        IRestResponse<T> _RestResponse;

        public RestRspns(IRestResponse<T> response)
            :base(response)
        {
            _RestResponse = response;
        }

        public T Data { get => _RestResponse.Data; set => _RestResponse.Data = value; }
    }

    public class RestServiceIOS : INetworkInteraction //: INetworkInteraction
    {
        public RestServiceIOS()
        {
            //client = new RestClient(Constants.BASE_URL);
            //var jsonDeserializer = new JsonDeserializer();
            //client.AddHandler("application/json", jsonDeserializer);
            //client.RemoveHandler("application/xml");
        }

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
            IRestResponse<T> response;
            try
            {
                var request = new RestRequest("/login", Method.POST);
                var user = new { username = "bianca@gmail.com", password = "PassM3" };
                request.AddJsonBody(JsonConvert.SerializeObject(user));
                response = await client.ExecuteTaskAsync<T>(request);
            }
            catch(Exception excp)
            {
                return null;
            }
            return new RestRspns<T>(response);
        }


        //public Func<Task<IRestResponse>> GetNetworkCallAsync(
        //          string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, object> paramterCollection)
        //{
        //Method returnNetworkType;
        //switch (networkCallType)
        //{
        //	default:
        //		returnNetworkType = Method.GET;
        //		break;
        //	case BaseNetworkAccessEnum.Post:
        //		returnNetworkType = Method.POST;
        //		break;
        //	case BaseNetworkAccessEnum.Put:
        //		returnNetworkType = Method.PUT;
        //		break;
        //}

        //	RestRequest req = new RestRequest(urlExtension, returnNetworkType);
        //	foreach (string key in paramterCollection.Keys)
        //	{
        //		req.AddParameter(key, paramterCollection[key]);
        //	}
        //	return async() => await client.ExecuteTaskAsync(req);
        //}

        //      public Func<Task<IRestResponse>> GetNetworkCallAsync(
        //	string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection)
        //{
        //	Method returnNetworkType;
        //	switch (networkCallType)
        //	{
        //		default:
        //			returnNetworkType = Method.GET;
        //			break;
        //		case BaseNetworkAccessEnum.Post:
        //			returnNetworkType = Method.POST;
        //			break;
        //		case BaseNetworkAccessEnum.Put:
        //			returnNetworkType = Method.PUT;
        //			break;
        //	}

        //	RestRequest req = new RestRequest(urlExtension, returnNetworkType);
        //	foreach (string key in paramterCollection.Keys)
        //	{
        //              var parameter = paramterCollection[key];
        //		switch(parameter.ParameterType)
        //              {
        //                  case ParameterTypeEnum.ValueParameter:
        //				req.AddParameter(key, parameter.ParameterValue);
        //                      break;
        //                  case ParameterTypeEnum.FileParameter:
        //                      req.AddFile(key, (byte[])parameter.ParameterValue, "cFile");
        //                      break;
        //                  case ParameterTypeEnum.HeaderParameter:
        //                      req.AddHeader(key, parameter.ToString());
        //                      break;
        //              }
        //	}
        //	return async () => await client.ExecuteTaskAsync(req);
        //}

        //      public Func<Task<IRestResponse<T>>> GetNetworkCallAsyncWithReturn<T>(
        //          string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection, 
        //          BaseViewModel body)
        //          where T: BaseViewModel
        //      {
        //          Method returnNetworkType;
        //          switch (networkCallType)
        //          {
        //              default:
        //                  returnNetworkType = Method.GET;
        //                  break;
        //              case BaseNetworkAccessEnum.Post:
        //                  returnNetworkType = Method.POST;
        //                  break;
        //              case BaseNetworkAccessEnum.Put:
        //                  returnNetworkType = Method.PUT;
        //                  break;
        //          }

        //          RestRequest req = new RestRequest(urlExtension, returnNetworkType);

        //          req.RequestFormat = DataFormat.Json;
        //          req.JsonSerializer = NewtonsoftJsonSerializer.Default;
        //          if (paramterCollection != null)
        //          {
        //              foreach (string key in paramterCollection.Keys)
        //              {
        //                  var parameter = paramterCollection[key];
        //                  switch (parameter.ParameterType)
        //                  {
        //                      case ParameterTypeEnum.ValueParameter:
        //                          req.AddParameter(key, parameter.ParameterValue);
        //                          break;
        //                      case ParameterTypeEnum.FileParameter:
        //                          req.AddFile(key, (byte[])parameter.ParameterValue, "cFile");
        //                          break;
        //                      case ParameterTypeEnum.HeaderParameter:
        //                          req.AddHeader(key, parameter.ParameterValue.ToString());
        //                          break;
        //                  }
        //              }
        //          }
        //          if (body != null)
        //          {
        //              req.AddJsonBody(body);
        //          }
        //          return async () =>
        //          {
        //              var client1 = new RestClient(Constants.BASE_URL);
        //              return await client1.ExecuteTaskAsync<T>(req);
        //          };
        //      }

        //      public async Task HandleNetworkResponseWithCallAsync(Func<Task<IRestResponse>> call)
        //{
        //          NetworkCallInitialised?.Invoke(this, new EventArgs());
        //          IRestResponse networkResponse = null;
        //	try
        //	{
        //		networkResponse = await call();
        //		var networkEventArgs = new NetworkCallEventArgs(
        //			networkResponse.StatusCode == System.Net.HttpStatusCode.OK, 
        //                  networkResponse.StatusDescription,
        //                  networkResponse.Content.StartsWith("{", StringComparison.OrdinalIgnoreCase)
        //              );
        //		if (networkResponse.StatusCode == System.Net.HttpStatusCode.OK && NetworkInteractionSucceeded != null)
        //		{
        //                  networkEventArgs.RawBytes = networkResponse.RawBytes;
        //                  networkEventArgs.NetworkResponseContent = networkResponse.Content;
        //			NetworkInteractionSucceeded(this, networkEventArgs);
        //              }
        //		else
        //		{
        //                  NetworkInteractionFailed?.Invoke(this, networkEventArgs);
        //              }
        //	}
        //	catch (Exception excp)
        //	{
        //              NetworkCallCompleted?.Invoke(this, new EventArgs());
        //              var networkEventArgs = new NetworkCallEventArgs(false, "Error occured");
        //		networkEventArgs.Exception = excp;
        //              NetworkInteractionFailed?.Invoke(this, networkEventArgs);
        //          }
        //	finally
        //	{
        //              NetworkCallCompleted?.Invoke(this, new EventArgs());
        //          }
        //}

        //      public async Task<IRestResponse<T>> HandleNetworkResponseWithCallAsync<T>(Func<Task<IRestResponse<T>>> call)
        //	where T: BaseViewModel
        //{
        //	NetworkCallInitialised?.Invoke(this, new EventArgs());
        //	IRestResponse<T> networkResponse = null;
        //	try
        //	{
        //		networkResponse = await call();
        //		var networkEventArgs = new NetworkCallEventArgs(
        //			networkResponse.StatusCode == System.Net.HttpStatusCode.OK,
        //			networkResponse.StatusDescription,
        //			networkResponse.Content.StartsWith("{", StringComparison.OrdinalIgnoreCase)
        //		);
        //		if (networkResponse.StatusCode == System.Net.HttpStatusCode.OK && NetworkInteractionSucceeded != null)
        //		{
        //			networkEventArgs.RawBytes = networkResponse.RawBytes;
        //			networkEventArgs.NetworkResponseContent = networkResponse.Content;
        //			NetworkInteractionSucceeded(this, networkEventArgs);
        //		}
        //		else
        //		{
        //			NetworkInteractionFailed?.Invoke(this, networkEventArgs);
        //		}
        //	}
        //	catch (Exception excp)
        //	{
        //		NetworkCallCompleted?.Invoke(this, new EventArgs());
        //		var networkEventArgs = new NetworkCallEventArgs(false, "Error occured");
        //		networkEventArgs.Exception = excp;
        //		NetworkInteractionFailed?.Invoke(this, networkEventArgs);
        //	}
        //	finally
        //	{
        //		NetworkCallCompleted?.Invoke(this, new EventArgs());
        //	}
        //	return networkResponse;
        //}

        //      public async Task ExecuteNetworkRequestAsync(
        //          string urlExtension, Dictionary<string, object> paramterCollection, BaseNetworkAccessEnum networkCallType)
        //      {
        //          _urlExtension = urlExtension;
        //          _networkCallType = networkCallType;
        //          await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        //      }

        //public async Task ExecuteNetworkRequestAsync(
        //	string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkCallType)
        //{
        //          _urlExtension = urlExtension;
        //          _networkCallType = networkCallType;
        //          await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        //}

        //public async Task<T> ExecuteNetworkRequestAsync<T>(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection,
        //                                             BaseViewModel body, BaseNetworkAccessEnum networkCallType)
        //    where T: BaseViewModel
        //{
        //    _urlExtension = urlExtension;
        //    _networkCallType = networkCallType;
        //    var tt = await HandleNetworkResponseWithCallAsync(GetNetworkCallAsyncWithReturn<T>(urlExtension, networkCallType, paramterCollection, body));
        //    return tt.Data;
        //}
    }
}
