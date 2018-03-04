using System;
namespace HiRes
{
    public static class Constants
    {
        public static string APPLICATION_TYPE = "application/json";
		// URL of REST service
#if DEBUG
		public static string BASE_URL = "http://sm2.respublica.co.za/API/api/AppAPI";
#else
		public static string BASE_URL = "http://sm.respublica.co.za/API/api/AppAPI";
#endif
		public static int SCREEN_AVAILABLE_HEIGHT = 100;
    }
}
