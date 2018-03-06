using CorePCL;
using Newtonsoft.Json;

namespace HiRes.ViewModel.ReturnModel
{
    public class LoginResponseUser : BaseViewModel
    {
        [JsonProperty("user_id")]
        public int UserID { get; set; }
        [JsonProperty("student_manager_id")]
        public int StudentManagerID { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
