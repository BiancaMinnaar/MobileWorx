using System;
using System.Net.Http;
using System.Threading.Tasks;

//[assembly: Xamarin.Forms.Dependency(typeof(RestService))]
namespace CorePCL
{
    public class RestService: IRestService
    {
        private HttpClient _client = new HttpClient();
        private string _baseUrl;

        public event EventHandler<NetworkCallEventArgs> NetworkInteractionSucceeded;
        public event EventHandler<NetworkCallEventArgs> NetworkInteractionFailed;

        public event EventHandler NetworkCallInitialised;
        public event EventHandler NetworkCallCompleted;

        public RestService(string baseURL)
        {
            _baseUrl = baseURL;
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task Get(string urlExtension) 
        {
            await performHttpOperation(async () => await _client.GetAsync(_baseUrl + urlExtension).ConfigureAwait(false));
        }

        public async Task Post(string urlExtension, HttpContent content) 
        { 
            await performHttpOperation(async () => await _client.PostAsync(_baseUrl + urlExtension, content).ConfigureAwait(false));
        }

        public async Task Put(string urlExtension, HttpContent content) 
        {
            await performHttpOperation(async () => await _client.PutAsync(_baseUrl + urlExtension, content).ConfigureAwait(false));
        }

        private async Task performHttpOperation(Func<Task<HttpResponseMessage>> httpOperation)
        {
            if (NetworkCallInitialised != null)
                NetworkCallInitialised(this, new EventArgs());
            HttpResponseMessage networkResponse = null;
            try
            {
                networkResponse = await httpOperation();
                var networkEventArgs = new NetworkCallEventArgs(networkResponse.IsSuccessStatusCode, networkResponse.ReasonPhrase);
                if (networkResponse.IsSuccessStatusCode && NetworkInteractionSucceeded != null)
                {
                    networkEventArgs.NetworkResponseContent = await networkResponse.Content.ReadAsStringAsync();
                    NetworkInteractionSucceeded(this, networkEventArgs);
                }
                else
                {
                    if (NetworkInteractionFailed != null)
                        NetworkInteractionFailed(this, networkEventArgs);
                }
            }
            catch (HttpRequestException httpExcp)
            {
                if (NetworkCallCompleted != null)
                    NetworkCallCompleted(this, new EventArgs());
                var networkEventArgs = new NetworkCallEventArgs(false, "HttpRequest Error occured");
                networkEventArgs.Exception = httpExcp;
                if (NetworkInteractionFailed != null)

                    NetworkInteractionFailed(this, networkEventArgs);
            }
            catch (Exception excp)
            {
                if (NetworkCallCompleted != null)
                    NetworkCallCompleted(this, new EventArgs());
                var networkEventArgs = new NetworkCallEventArgs(false, "Error occured");
                networkEventArgs.Exception = excp;
                if (NetworkInteractionFailed != null)
                    NetworkInteractionFailed(this, networkEventArgs);
            }
            finally
            {
                if (NetworkCallCompleted != null)
                    NetworkCallCompleted(this, new EventArgs());
            }
        }
    }
}
