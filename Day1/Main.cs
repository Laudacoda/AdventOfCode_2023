using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day1
{
	public static class Main
	{
		// 54338
		public static int Execute()
		{
			var sum = 0;
			var regex = new Regex("\\d+");
			
			foreach (var str in File.ReadAllLines("..\\..\\..\\Day1\\Input.txt"))
			{
				var matches = regex.Matches(str);
				var val1 = (matches[0].Value[0] - '0') + (matches[^1].Value[^1] - '0').ToString();
				sum += int.Parse(val1);
			}
			return sum;
		}

		public static int OptimizedExecute()
		{
			var sum = 0;

			foreach (var str in File.ReadAllLines("..\\..\\..\\Day1\\Input.txt"))
			{
				var left = str.First(char.IsDigit) - '0';
				var right = str.Last(char.IsDigit) - '0';
				sum += left * 10 + right;
			}

			return sum;
		}
	}
}