using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyString
{
	public static partial class ComparisonMetrics
	{
		public static double JaroWinklerDistance(this string source, string target)
		{
			double jaroDistance = source.JaroDistance(target);
			double commonPrefixLength = CommonPrefixLength(source, target);

			return jaroDistance + (commonPrefixLength * 0.1 * (1 - jaroDistance));
		}

		public static double JaroWinklerDistanceWithPrefixScale(string source, string target, double p)
		{
			double prefixScale = 0.1;

			if (p > 0.25) { prefixScale = 0.25; } // The maximu value for distance to not exceed 1
			else if (p < 0) { prefixScale = 0; } // The Jaro Distance
			else { prefixScale = p; }

			double jaroDistance = source.JaroDistance(target);
			double commonPrefixLength = CommonPrefixLength(source, target);

			return jaroDistance + (commonPrefixLength * prefixScale * (1 - jaroDistance));
		}

		private static double CommonPrefixLength(string source, string target)
		{
			int maximumPrefixLength = 4;
			int commonPrefixLength = 0;
			if (source.Length <= 4 || target.Length <= 4) { maximumPrefixLength = Math.Min(source.Length, target.Length); }

			for (int i = 0; i < maximumPrefixLength; i++)
			{
				if (source[i].Equals(target[i])) { commonPrefixLength++; }
				else { return commonPrefixLength; }
			}

			return commonPrefixLength;
		}
	}
}
