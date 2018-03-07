using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class StringExtensions
	{
		public static bool IsNotNullOrEmpty(this string value)
		{
			return value.IsNullOrEmpty() == false;
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return String.IsNullOrEmpty(value);
		}
	}
}
