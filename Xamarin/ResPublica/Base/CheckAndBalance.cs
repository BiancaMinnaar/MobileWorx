using System;
namespace HiRes.Base
{
	public class BrokenRule
	{
		public Func<bool> Check { get; set; }
		public string Balance { get; set; }
	}
}
