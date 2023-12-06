namespace AdventOfCode.Day6;

public static class Main
{
    public static int ExecutePart1()
    {
        var strings = File.ReadAllLines(@"..\..\..\Day6\Input.txt");

        long[] times = strings[0].Split(":")[1].Trim().Replace("  ", " ").Split(" ").Select(long.Parse).ToArray();
        long[] distances = strings[1].Split(":")[1].Trim().Replace("  ", " ").Split(" ").Select(long.Parse).ToArray();

        var multiplier = 1;
        
        for (int i = 0; i < times.Length; i++)
        {
            var t = times[i];
            var d = distances[i];

            var tLow = t / 2;
            var tHigh = tLow < t / 2f ? tLow + 1 : tLow;
            
            var offset = 0;
            
            while ((tLow - offset) * (tHigh +offset) > d)
                offset++;

            if (tLow == tHigh) multiplier *= offset * 2 - 1;
            else multiplier *= offset * 2;
        }
        
        return multiplier;
    }

    public static int ExecutePart2()
    {
        return 0;
    }
}
