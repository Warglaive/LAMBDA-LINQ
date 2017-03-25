using System;
using System.Collections.Generic;
using System.Linq;

public class CottageScraper
{
    public static void Main()
    {
        var line = Console.ReadLine();
        var dict = new Dictionary<string, List<decimal>>();
        while (line != "chop chop")
        {
            var tokens = line.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            var treeType = tokens[0];
            var height = decimal.Parse(tokens[1]);
            if (!dict.ContainsKey(treeType))
            {
                dict[treeType] = new List<decimal>();
            }
            dict[treeType].Add(height);
            line = Console.ReadLine();
        }
        var typeOfTree = Console.ReadLine();
        var minLenghtPerTree = decimal.Parse(Console.ReadLine());
        var pricePerMeter = Math.Round(GetThePricePerMeter(dict), 2);
        var filteredUsedLogs = dict
            .Where(x => x.Key.Equals(typeOfTree))
            .SelectMany(x => x.Value.Where(y => y >= minLenghtPerTree)
            .ToList());
        var usedLogsPrice = Math.Round(filteredUsedLogs.Sum() * pricePerMeter, 2);
        var unusedLogs = Math.Round(dict.Sum(x => x.Value.Sum()) - filteredUsedLogs.Sum(), 2);
        var unusedLogsPrice = Math.Round(unusedLogs * pricePerMeter * 0.25m, 2);
        var cottageScraperSubTotal = Math.Round(usedLogsPrice + unusedLogsPrice, 2);
        Console.WriteLine($"Price per meter: ${pricePerMeter:f2}");
        Console.WriteLine($"Used logs price: ${usedLogsPrice:f2}");
        Console.WriteLine($"Unused logs price: ${unusedLogsPrice:f2}");
        Console.WriteLine($"CottageScraper subtotal: ${cottageScraperSubTotal:f2}");
    }
    private static decimal GetThePricePerMeter(Dictionary<string, List<decimal>> dict)
    {
        var sumOfAllLogs = dict.Sum(x => x.Value.Sum());
        var count = dict.Values.Sum(x => x.Count);

        return sumOfAllLogs / count;
    }
}