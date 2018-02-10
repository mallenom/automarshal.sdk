using System;

namespace Recar2.Samples
{
	static class Extensions
	{
		public static decimal ToPercent(this double value)
		{
			return (decimal)(100.0 * value);
		}

		public static decimal ToPercent(this float value)
		{
			return ((double)value).ToPercent();
		}

		public static double FromPercent(this decimal value)
		{
			return (double)value / 100.0;
		}

	}
}
