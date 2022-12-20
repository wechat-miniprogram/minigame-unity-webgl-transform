using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyString
{
	public static partial class ComparisonMetrics
	{
		public static string LongestCommonSubstring(this string source, string target)
		{
			if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(target)) { return null; }

			int[,] L = new int[source.Length, target.Length];
			int maximumLength = 0;
			int lastSubsBegin = 0;
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < source.Length; i++)
			{
				for (int j = 0; j < target.Length; j++)
				{
					if (source[i] != target[j])
					{
						L[i, j] = 0;
					}
					else
					{
						if ((i == 0) || (j == 0))
							L[i, j] = 1;
						else
							L[i, j] = 1 + L[i - 1, j - 1];

						if (L[i, j] > maximumLength)
						{
							maximumLength = L[i, j];
							int thisSubsBegin = i - L[i, j] + 1;
							if (lastSubsBegin == thisSubsBegin)
							{//if the current LCS is the same as the last time this block ran
								stringBuilder.Append(source[i]);
							}
							else //this block resets the string builder if a different LCS is found
							{
								lastSubsBegin = thisSubsBegin;
								stringBuilder.Length = 0; //clear it
								stringBuilder.Append(source.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
							}
						}
					}
				}
			}

			return stringBuilder.ToString();
		}

	}
}
