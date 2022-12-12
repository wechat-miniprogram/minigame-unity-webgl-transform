using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyString
{
	public static partial class ComparisonMetrics
	{
		public static string LongestCommonSubsequence(this string source, string target)
		{
			int[,] C = LongestCommonSubsequenceLengthTable(source, target);

			return Backtrack(C, source, target, source.Length, target.Length);
		}

		private static int[,] LongestCommonSubsequenceLengthTable(string source, string target)
		{
			int[,] C = new int[source.Length + 1, target.Length + 1];

			for (int i = 0; i < source.Length + 1; i++) { C[i, 0] = 0; }
			for (int j = 0; j < target.Length + 1; j++) { C[0, j] = 0; }

			for (int i = 1; i < source.Length + 1; i++)
			{
				for (int j = 1; j < target.Length + 1; j++)
				{
					if (source[i - 1].Equals(target[j - 1]))
					{
						C[i, j] = C[i - 1, j - 1] + 1;
					}
					else
					{
						C[i, j] = Math.Max(C[i, j - 1], C[i - 1, j]);
					}
				}
			}

			return C;
		}

		private static string Backtrack(int[,] C, string source, string target, int i, int j)
		{
			if (i == 0 || j == 0)
			{
				return "";
			}
			else if (source[i - 1].Equals(target[j - 1]))
			{
				return Backtrack(C, source, target, i - 1, j - 1) + source[i - 1];
			}
			else
			{
				if (C[i, j - 1] > C[i - 1, j])
				{
					return Backtrack(C, source, target, i, j - 1);
				}
				else
				{
					return Backtrack(C, source, target, i - 1, j);
				}
			}
		}
	}
}
