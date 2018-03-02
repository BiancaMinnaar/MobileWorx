using System;
using CorePCL;
using Xamarin.Forms;
using MeasurePro.Droid.Injection;
using BasePCL.DataContracts.Interface;
using System.Collections.Generic;
using RestSharp;
using System.Threading.Tasks;
using HiRes;

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

                    //if (_urlExtension != null &&_urlExtension.Equals("/Workflow/SaveAnswers/{Answers}", StringComparison.CurrentCultureIgnoreCase))
                    //{
                    //    _urlExtension = null;
                    //    AnswersUploadSucceeded(this, networkEventArgs);
                    //}
                    //if (_urlExtension != null &&_urlExtension.Equals("/Gallary/{Photo}", StringComparison.CurrentCultureIgnoreCase) && _networkCallType == BaseNetworkAccessEnum.Post)
                    //{
                    //    networkEventArgs.ObjectID = _photoID;
                    //    _urlExtension = null;
                    //    _photoID = 0;
                    //    PhotoUploadSucceeded(this, networkEventArgs);
                    //}
                }
				else
				{
                    networkEventArgs = new NetworkCallEventArgs(false, "Issues connecting to remote server");
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

		public async Task ExecuteNetworkRequestAsync(
			string urlExtension, Dictionary<string, ParameterTypedValue> paramterCollection, BaseNetworkAccessEnum networkCallType)
		{
            _urlExtension = urlExtension;
            _networkCallType = networkCallType;
            if (paramterCollection.ContainsKey("Id"))
            {
                var parameter = paramterCollection["Id"];
                if (parameter.ParameterType == ParameterTypeEnum.IdParameter)
                {
                    _photoID = Int32.Parse(parameter.ParameterValue.ToString());
                    paramterCollection.Remove("Id");
                }
            }
            await handleNetworkResponseWithCallAsync(GetNetworkCallAsync(urlExtension, networkCallType, paramterCollection));
		}
    }
}
