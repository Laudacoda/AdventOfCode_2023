namespace AdventOfCode.Day5;

public static class Main
{
    public static long ExecutePart1()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day5\Input.txt");

        long[] seeds = strings[0].Split(":")[1].Trim().Replace("  ", " ").Split(" ").Select(long.Parse).ToArray();
        
        int i = 2;

        for (int j = 0; j < 7; j++)
        {
            while (!char.IsDigit(strings[i][0])) i++;

            var map = SetMap(strings, i);

            for (int k = 0; k < seeds.Length; k++)
            {
                seeds[k] = ProcessMap(seeds[k], map);
            }
            
            while (i < strings.Length && strings[i].Length > 0) i++;
            i++;
        }
        
        return seeds.Min();
    }

    private static List<long[]> SetMap(string[] strings, long index)
    {
        List<long[]> map = new List<long[]>();

        int i = 0;

        while (index + i < strings. Length && strings[index + i].Length > 0)
        {
            long[] line = strings[index + i]
                .Split(" ")
                .Select(long.Parse)
                .ToArray();
            
            map.Add(line);
            i++;
        }
        
        return map;
    }

    private static long ProcessMap(long input, List<long[]> map)
    {
        int i = 0;

        while (i <= map.Count -1 && !(input - map[i][1] >= 0 && input - map[i][1] <= map[i][2]))
            i++;

        if (i >= map.Count)
            return input;

        return input - map[i][1] + map[i][0];
    }
}
