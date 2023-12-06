namespace AdventOfCode.Day4;

public static class Main
{
    public static int ExecutePart1()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day4\Input.txt");

        var sum = 0;
        
        foreach (var s in strings)
        {
            string[] numberStrings = s.Split(":")[1].Split("|");
            var winningNumbers = numberStrings[0].Trim().Replace("  ", " ").Split(" ").Select(int.Parse);
            var numbers = numberStrings[1].Trim().Replace("  ", " ").Split(" ").Select(int.Parse);
            
            var matches = numbers.Count(x => winningNumbers.Any(y => x == y));
            if (matches >= 1) sum += (int) Math.Pow(2, matches - 1);
        }

        return sum;
    }

    public static int ExecutePart2()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day4\Input.txt");

        var matches = new List<int>(strings.Length);
        
        foreach (var s in strings)
        {
            string[] numberStrings = s.Split(":")[1].Split("|");
            var winningNumbers = numberStrings[0].Trim().Replace("  ", " ").Split(" ").Select(int.Parse);
            var numbers = numberStrings[1].Trim().Replace("  ", " ").Split(" ").Select(int.Parse);
            
            matches.Add(numbers.Count(x => winningNumbers.Any(y => x == y)));
        }

        var duplicates = Enumerable.Repeat(1, strings.Length).ToList();

        for (int i = 0; i < duplicates.Count; i++)
        {
            for (int j = 0; j < matches[i]; j++)
            {
                duplicates[i + j + 1] += duplicates[i];
            }
        }

        return duplicates.Sum();
    }
}
