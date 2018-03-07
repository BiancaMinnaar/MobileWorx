using HiRes.Base;
using Newtonsoft.Json;

namespace HiRes.ViewModel.ReturnModel
{
    public class LoginResponseUser : ProjectBaseViewModel
    {
		public StatusDto Status { get; set; }

		[JsonProperty("user_id")]
        public int UserID { get; set; }
        [JsonProperty("student_manager_id")]
        public int StudentManagerID { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }

	public class StatusDto
	{
		public string Message { get; set; }
		public int StatusCode { get; set; }
	}
}
