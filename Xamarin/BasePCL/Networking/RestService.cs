using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Xamarin.Forms;

namespace BasePCL.Networking
{
    public class RestService
    {
        INetworkInteraction _Client;
        string _UrlExtension;
        BaseNetworkAccessEnum _NetworkCallType;

        public event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;
        public event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;
        public event EventHandler NetworkCallInitialised;
        public event EventHandler NetworkCallCompleted;

        public RestService()
        {
            _Client = DependencyService.Get<INetworkInteraction>();
        }

        private Func<Task<INetworkResponse>> GetNetworkCallAsync(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, object> paramterCollection)
        {
            var req = _Client.GetNetworkRequest(urlExtension, networkCallType);
            foreach (string key in paramterCollection.Keys)
            {
                req.AddParameter(key, paramterCollection[key]);
            }
            return async () => await _Client.ExecuteTaskAsync(req);
        }

        private Func<Task<INetworkResponse>> GetNetworkCallAsync(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection)
        {
            var req = _Client.GetNetworkRequest(urlExtension, networkCallType);
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
            return async () => await _Client.ExecuteTaskAsync(req);
        }

        private Func<Task<INetworkResponse<T>>> GetNetworkCallAsyncWithReturn<T>(
            string urlExtension, BaseNetworkAccessEnum networkCallType, Dictionary<string, ParameterTypedValue> paramterCollection,
            BaseViewModel body)
            where T : BaseViewModel
        {
            var req = _Client.GetNetworkRequestForJson(urlExtension, networkCallType);

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
                return await _Client.ExecuteTaskAsync<T>(req);
            };
        }

        async Task HandleNetworkResponseWithCallAsync(Func<Task<INetworkResponse>> call)
        {
            NetworkCallInitialised?.Invoke(this, new EventArgs());
            INetworkResponse networkResponse = null;
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

        async Task<INetworkResponse<T>> HandleNetworkResponseWithCallAsync<T>(Func<Task<INetworkResponse<T>>> call)
            where T : BaseViewModel
        {
            NetworkCallInitialised?.Invoke(this, new EventArgs());
            INetworkResponse<T> networkResponse = null;
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
            string urlExtension, Dictionary<string, object> paramterCollection, BaseNetworkAccessEnum networkCallType)
        {
            _UrlExtension = urlExtension;
            _NetworkCallType = networkCallType;
            await HandleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        }

        public async Task ExecuteNetworkRequestAsync(
            string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkCallType)
        {
            _UrlExtension = urlExtension;
            _NetworkCallType = networkCallType;
            await HandleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
        }

        public async Task<T> ExecuteNetworkRequestAsync<T>(string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection,
                                                     BaseViewModel body, BaseNetworkAccessEnum networkCallType)
            where T : BaseViewModel
        {
            _UrlExtension = urlExtension;
            _NetworkCallType = networkCallType;
            var tt = await HandleNetworkResponseWithCallAsync(GetNetworkCallAsyncWithReturn<T>(urlExtension, networkCallType, paramterCollection, body));
            return tt.Data;
        }
    }
}
