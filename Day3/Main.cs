using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public static class Main
{
    public static long ExecutePart1()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day3\Input.txt");
        var symbolRegex = new Regex(@"[^.\d]");
        long sum = 0;
        
        for (int i = 0; i < strings.Length; i++)
        {
            var matches = symbolRegex.Matches(strings[i]);
            
            foreach (Match match in matches)
            {
                if (i > 0) sum += FindValues(strings[i - 1], match.Index); // top row
                sum += FindValues(strings[i], match.Index); // current row
                if (i < strings.Length - 1) sum += FindValues(strings[i + 1], match.Index); // bottom row
            }
        }
        
        return sum;
    }

    public static long ExecutePart2()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day3\Input.txt");
        var symbolRegex = new Regex(@"[^.\d]");
        long sum = 0;
        
        for (int i = 0; i < strings.Length; i++)
        {
            var str = strings[i];
            var matches = symbolRegex.Matches(strings[i]);
            
            foreach (Match match in matches)
            {
                int checkNeighbours = 0;
                long multiplier = 1;
                if (i > 0) checkNeighbours = CheckNeighbours(strings[i - 1], match.Index);
                checkNeighbours += CheckNeighbours(strings[i], match.Index);
                if (i < strings.Length - 1) checkNeighbours += CheckNeighbours(strings[i + 1], match.Index);

                if (checkNeighbours != 2) continue;
                
                if (i > 0) multiplier *= FindValues(strings[i - 1], match.Index, true); // top row
                multiplier *= FindValues(strings[i], match.Index, true); // current row
                if (i < strings.Length - 1) multiplier *= FindValues(strings[i + 1], match.Index, true); // bottom row

                sum += multiplier;
            }
        }
        
        return sum;
    }
    
    private static long FindValues(string s, int index, bool multiply = false)
    {
        var sb = new StringBuilder();
        var fullNumber = char.IsDigit(s[index]);
        
        var j = fullNumber ? index : index - 1;
        while (j >= 0 && char.IsDigit(s[j]))
        {
            sb.Append(s[j]);
            j--;
        }
        
        var left = sb.Length > 0 ? long.Parse(Reverse(sb.ToString())) : multiply ? 1 : 0;

        sb.Clear();
        
        j = index + 1;
        while (j <= s.Length - 1 && char.IsDigit(s[j]))
        {
            sb.Append(s[j]);
            j++;
        }

        var right = sb.Length > 0 ? long.Parse(sb.ToString()) : multiply ? 1 : 0;
        var result = fullNumber ? long.Parse($"{left}{sb.ToString()}") : (multiply ? left * right : left + right);
        return result;
    }
    
    private static int CheckNeighbours(string s, int index)
    {
        if (char.IsDigit(s[index])) return 1;

        var count = 0;
        if (index > 0 && char.IsDigit(s[index - 1])) count++;
        if (index < s.Length - 1 && char.IsDigit(s[index + 1])) count++;

        return count;
    }
    
    private static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}