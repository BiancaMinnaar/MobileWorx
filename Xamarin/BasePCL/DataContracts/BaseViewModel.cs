using Newtonsoft.Json;

namespace CorePCL
{
	public abstract class BaseViewModel
	{
		public string SerializeObject()
		{
			return JsonConvert.SerializeObject(this);
		}

		public string device { get; set; } = Plugin.DeviceInfo.CrossDeviceInfo.Current.GenerateAppId(true);
		public string token_type { get; set; } = "app";

		[JsonProperty("X-API-KEY")]
		public string X_API_KEY { get; set; } = "boguskey_rsl";

	}
}
