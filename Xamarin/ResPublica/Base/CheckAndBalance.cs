using System;
namespace ResPublica.Base
{
	public class CheckAndBalance
	{
		public Func<bool> Check { get; set; }
		public string Balance { get; set; }
	}
}
