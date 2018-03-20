using System;
namespace CorePCL
{
	public class BrokenRule
	{
		public Func<bool> Check { get; set; }
		public string Balance { get; set; }
	}
}
