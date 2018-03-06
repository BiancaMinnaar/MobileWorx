using System;
using CorePCL;
using Newtonsoft.Json;

namespace HiRes.ViewModel
{
    public class UserModel : BaseViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string token_type { get; set; }
        public string device { get; set; }
        [JsonProperty("X-API-KEY")]
        public string X_API_KEY { get; set; }
    }
}
