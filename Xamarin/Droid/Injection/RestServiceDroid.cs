using System;
using CorePCL;
using Xamarin.Forms;
using MeasurePro.Droid.Injection;
using BasePCL.DataContracts.Interface;
using System.Collections.Generic;
using RestSharp;
using System.Threading.Tasks;
using HiRes;
using ResPublica.Droid.Injection;
using RestSharp.Deserializers;

[assembly: Dependency(typeof(RestServiceDroid))]
namespace MeasurePro.Droid.Injection
{
    public class RestServiceDroid : INetworkInteraction
    {
        private RestClient client;
        private string _urlExtension;
        private BaseNetworkAccessEnum _networkCallType;
        private int _photoID;

        public event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;
        public event EventHandler<NetworkCallEventArgs> AnswersUploadSucceeded;
        public event EventHandler<NetworkCallEventArgs> PhotoUploadSucceeded;
        public event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;
        public event EventHandler NetworkCallInitialised;
        public event EventHandler NetworkCallCompleted;

        public RestServiceDroid()
        {
            client = new RestClient(Constants.BASE_URL);
            var jsonDeserializer = new JsonDeserializer();
            client.AddHandler("application/json", jsonDeserializer);
            client.RemoveHandler("application/xml");
        }

        private Func<IRestResponse> GetNetworkCall(string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, object> paramterCollection)
        {
            Method returnNetworkType;
            switch (networkCallType)
            {
                default:
                    returnNetworkType = Method.GET;
                    break;
                case BaseNetworkAccessEnum.Post:
                    returnNetworkType = Method.POST;
                    break;
                case BaseNetworkAccessEnum.Put:
                    returnNetworkType = Method.PUT;
                    break;
            }

            RestRequest req = new RestRequest(urlExtension, returnNetworkType);
            foreach (string key in paramterCollection.Keys)
            {
                req.AddParameter(key, paramterCollection[key]);
            }
            return () => client.Execute(req);
        }

        private Func<Task<IRestResponse>> GetNetworkCallAsync(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, object> paramterCollection)
        {
            Method returnNetworkType;
            switch (networkCallType)
            {
                default:
                    returnNetworkType = Method.GET;
                    break;
                case BaseNetworkAccessEnum.Post:
                    returnNetworkType = Method.POST;
                    break;
                case BaseNetworkAccessEnum.Put:
                    returnNetworkType = Method.PUT;
                    break;
            }

            RestRequest req = new RestRequest(urlExtension, returnNetworkType);
            foreach (string key in paramterCollection.Keys)
            {
                req.AddParameter(key, paramterCollection[key]);
            }
            return async () => await client.ExecuteTaskAsync(req);
        }

        private Func<Task<IRestResponse>> GetNetworkCallAsync(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection)
        {
            Method returnNetworkType;
            switch (networkCallType)
            {
                default:
                    returnNetworkType = Method.GET;
                    break;
                case BaseNetworkAccessEnum.Post:
                    returnNetworkType = Method.POST;
                    break;
                case BaseNetworkAccessEnum.Put:
                    returnNetworkType = Method.PUT;
                    break;
            }

            RestRequest req = new RestRequest(urlExtension, returnNetworkType);
            foreach (string key in paramterCollection.Keys)
            {
                var parameter = paramterCollection[key];
                switch (parameter.ParameterType)
                {
                    case ParameterTypeEnum.ValueParameter:
                        req.AddParameter(key, parameter.ParameterValue);
                        break;
                    case ParameterTypeEnum.FileParameter:
                        req.AddFile(key, (byte[])parameter.ParameterValue, "cFile");
                        break;
                    case ParameterTypeEnum.HeaderParameter:
                        req.AddHeader(key, parameter.ToString());
                        break;
                }
            }
            return async () => await client.ExecuteTaskAsync(req);
        }

        private Func<Task<IRestResponse<T>>> GetNetworkCallAsyncWithReturn<T>(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection,
            BaseViewModel body)
            where T : BaseViewModel
        {
            Method returnNetworkType;
            switch (networkCallType)
            {
                default:
                    returnNetworkType = Method.GET;
                    break;
                case BaseNetworkAccessEnum.Post:
                    returnNetworkType = Method.POST;
                    break;
                case BaseNetworkAccessEnum.Put:
                    returnNetworkType = Method.PUT;
                    break;
            }

            RestRequest req = new RestRequest(urlExtension, returnNetworkType);

            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = NewtonsoftJsonSerializer.Default;
            if (paramterCollection != null)
            {
                foreach (string key in paramterCollection.Keys)
                {
                    var parameter = paramterCollection[key];
                    switch (parameter.ParameterType)
                    {
                        case ParameterTypeEnum.ValueParameter:
                            req.AddParameter(key, parameter.ParameterValue);
                            break;
                        case ParameterTypeEnum.FileParameter:
                            req.AddFile(key, (byte[])parameter.ParameterValue, "cFile");
                            break;
                        case ParameterTypeEnum.HeaderParameter:
                            req.AddHeader(key, parameter.ParameterValue.ToString());
                            break;
                    }
                }
            }
            if (body != null)
            {
                req.AddJsonBody(body);
            }
            return async () =>
            {
                var client1 = new RestClient(Constants.BASE_URL);
                return await client1.ExecuteTaskAsync<T>(req);
            };
        }

        private async Task handleNetworkResponseWithCallAsync(Func<Task<IRestResponse>> call)
        {
            NetworkCallInitialised?.Invoke(this, new EventArgs());
            IRestResponse networkResponse = null;
            try
            {
                networkResponse = await call();
                var networkEventArgs = new NetworkCallEventArgs(
                    networkResponse.StatusCode == System.Net.HttpStatusCode.OK,
                    networkResponse.StatusDescription,
                    networkResponse.Content.StartsWith("{", StringComparison.OrdinalIgnoreCase)
                );
                if (networkResponse.StatusCode == System.Net.HttpStatusCode.OK && NetworkInteractionSucceeded != null)
                {
                    networkEventArgs.RawBytes = networkResponse.RawBytes;
                    networkEventArgs.NetworkResponseContent = networkResponse.Content;
                    NetworkInteractionSucceeded(this, networkEventArgs);

                    if (_urlExtension != null && _urlExtension.Equals("/Workflow/SaveAnswers/{Answers}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        _urlExtension = null;
                        AnswersUploadSucceeded(this, networkEventArgs);
                    }
                    if (_urlExtension != null && _urlExtension.Equals("/Gallary/{Photo}", StringComparison.CurrentCultureIgnoreCase) && _networkCallType == BaseNetworkAccessEnum.Post)
                    {
                        networkEventArgs.ObjectID = _photoID;
                        _urlExtension = null;
                        _photoID = 0;
                        PhotoUploadSucceeded(this, networkEventArgs);
                    }
                }
                else
                {
                    NetworkInteractionFailed?.Invoke(this, networkEventArgs);
                }
            }
            catch (Exception excp)
            {
                NetworkCallCompleted?.Invoke(this, new EventArgs());
                var networkEventArgs = new NetworkCallEventArgs(false, "Error occured");
                networkEventArgs.Exception = excp;
                NetworkInteractionFailed?.Invoke(this, networkEventArgs);
            }
            finally
            {
                NetworkCallCompleted?.Invoke(this, new EventArgs());
            }
        }

        public async Task ExecuteNetworkRequestAsync(
            string urlExtension, Dictionary<string, object> paramterCollection, BaseNetworkAccessEnum networkCallType)
        {
            _urlExtension = urlExtension;
            _networkCallType = networkCallType;
            await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        }

        private async Task<IRestResponse<T>> HandleNetworkResponseWithCallAsync<T>(Func<Task<IRestResponse<T>>> call)
            where T : BaseViewModel
        {
            NetworkCallInitialised?.Invoke(this, new EventArgs());
            IRestResponse<T> networkResponse = null;
            try
            {
                networkResponse = await call();
                var networkEventArgs = new NetworkCallEventArgs(
                    networkResponse.StatusCode == System.Net.HttpStatusCode.OK,
                    networkResponse.StatusDescription,
                    networkResponse.Content.StartsWith("{", StringComparison.OrdinalIgnoreCase)
                );
                if (networkResponse.StatusCode == System.Net.HttpStatusCode.OK && NetworkInteractionSucceeded != null)
                {
                    networkEventArgs.RawBytes = networkResponse.RawBytes;
                    networkEventArgs.NetworkResponseContent = networkResponse.Content;
                    NetworkInteractionSucceeded(this, networkEventArgs);

                    if (_urlExtension != null && _urlExtension.Equals("/Workflow/SaveAnswers/{Answers}", StringComparison.CurrentCultureIgnoreCase))
                    {
                        _urlExtension = null;
                        AnswersUploadSucceeded(this, networkEventArgs);
                    }
                    if (_urlExtension != null && _urlExtension.Equals("/Gallary/{Photo}", StringComparison.CurrentCultureIgnoreCase) && _networkCallType == BaseNetworkAccessEnum.Post)
                    {
                        networkEventArgs.ObjectID = _photoID;
                        _urlExtension = null;
                        _photoID = 0;
                        PhotoUploadSucceeded(this, networkEventArgs);
                    }
                }
                else
                {
                    NetworkInteractionFailed?.Invoke(this, networkEventArgs);
                }
            }
            catch (Exception excp)
            {
                NetworkCallCompleted?.Invoke(this, new EventArgs());
                var networkEventArgs = new NetworkCallEventArgs(false, "Error occured");
                networkEventArgs.Exception = excp;
                NetworkInteractionFailed?.Invoke(this, networkEventArgs);
            }
            finally
            {
                NetworkCallCompleted?.Invoke(this, new EventArgs());
            }
            return networkResponse;
        }

        public async Task ExecuteNetworkRequestAsync(
            string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkCallType)
        {
            _urlExtension = urlExtension;
            _networkCallType = networkCallType;
            await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        }

        public async Task ExecuteNetworkRequestAsync(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection,
                                                     BaseViewModel body, BaseNetworkAccessEnum networkCallType)
        {
            throw new NotImplementedException("Here");
            //_urlExtension = urlExtension;
            //_networkCallType = networkCallType;
            //await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection, body));
        }

        public async Task<T> ExecuteNetworkRequestAsync<T>(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection,
                                                     BaseViewModel body, BaseNetworkAccessEnum networkCallType)
            where T : BaseViewModel
        {
            _urlExtension = urlExtension;
            _networkCallType = networkCallType;
            var tt = await HandleNetworkResponseWithCallAsync(GetNetworkCallAsyncWithReturn<T>(urlExtension, networkCallType, paramterCollection, body));
            return tt.Data;
        }
    }
}
