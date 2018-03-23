using CorePCL;
using Newtonsoft.Json;

namespace HiRes.ViewModel.ReturnModel
{
    public class LoginResponseUser : BaseViewModel
    {
		[JsonProperty("username")]
		public string UserName { get; set; }
        [JsonProperty("userId")]
        public int UserID { get; set; }
		public StatusDto Status { get; set; }
    }

	public class StatusDto
	{
		public string Message { get; set; }
		public int StatusCode { get; set; }
	}
}
