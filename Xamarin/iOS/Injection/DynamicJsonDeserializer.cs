using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace ResPublica.iOS.Injection
{
    public class DynamicJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)// where T : new()
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
