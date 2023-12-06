using System.Text.RegularExpressions;

namespace AdventOfCode.Day2;

public static class Main
{
    public static int  ExecutePart1()
    {
        var sum = 0;
        var id = 1;
        var regex = new Regex(@"(\d+ r)|(\d+ b)|(\d+ g)");
        var maxRgb = new [] {12, 13, 14};
        
        foreach (var str in File.ReadAllLines(@"..\..\..\Day2\Input.txt"))
        {
            var isValid = true;
            var games = str.Split(":")[1].Split(";");
            
            foreach (var game in games)
            {
                var matches = regex.Matches(game);
                var rgb = new int[3];

                foreach (Match match in matches)
                {
                    switch (match.Value[^1])
                    {
                        case 'r' :
                            rgb[0] = int.Parse(match.Value[..^2]);
                            break;
                        case 'g' :
                            rgb[1] = int.Parse(match.Value[..^2]);
                            break;
                        case 'b' :
                            rgb[2] = int.Parse(match.Value[..^2]);
                            break;
                    }
                }

                if (rgb[0] > maxRgb[0] || rgb[1] > maxRgb[1] || rgb[2] > maxRgb[2])
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid) sum += id;
            
            id++;
        }

        return sum;
    }
    
    public static long  ExecutePart2()
    {
        long sum = 0;
        var regex = new Regex(@"(\d+ r)|(\d+ b)|(\d+ g)");
        
        foreach (var str in File.ReadAllLines(@"..\..\..\Day2\Input.txt"))
        {
            var games = str.Split(":")[1].Split(";");
            var maxRgb = new [] {1, 1, 1};

            foreach (var game in games)
            {
                var matches = regex.Matches(game);

                foreach (Match match in matches)
                {
                    var value = int.Parse(match.Value[..^2]);
                    
                    switch (match.Value[^1])
                    {
                        case 'r' :
                            if (value > maxRgb[0]) maxRgb[0] = value;        
                            break;
                        case 'g' :
                            if (value > maxRgb[1]) maxRgb[1] = value;
                            break;
                        case 'b' :
                            if (value > maxRgb[2]) maxRgb[2] = value;
                            break;
                    }
                }
            }
            
            sum += maxRgb[0] * maxRgb[1] * maxRgb[2];
        }

        return sum;
    }
}
