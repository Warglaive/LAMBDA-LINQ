using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class LINQuistics
{
    public static void Main()
    {
        var collections = new Dictionary<string, HashSet<string>>();
        var input = Console.ReadLine()
            .Split(new[] { '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        while (input[0] != "exit")
        {
            if (input.Count > 1)
            {
                var currentCollection = input[0];
                var currentMethods = input.GetRange(1, input.Count - 1);
                if (!collections.ContainsKey(currentCollection))
                {
                    collections[currentCollection] = new HashSet<string>();
                }
                foreach (var method in currentMethods)
                {
                    collections[currentCollection].Add(method);
                }
            }
            else
            {
                var isNumber = Regex.IsMatch(input[0], @"^\d+$");
                if (!isNumber)
                {
                    var currentCollection = input[0];
                    if (collections.ContainsKey(currentCollection))
                    {
                        foreach (var method in collections[currentCollection].OrderByDescending(x => x.Length)
                            .ThenByDescending(x => x.Distinct().Count()))
                        {
                            Console.WriteLine($"* {method}");
                        }
                    }
                }
                else
                {
                    var n = int.Parse(input[0]);
                    var collectionMethods = collections
                        .OrderByDescending(x => x.Value.Count())
                        .Take(1)
                        .SelectMany(x => x.Value)
                        .ToList();
                    foreach (var method in collectionMethods.OrderBy(x => x.Length).Take(n))
                    {
                        Console.WriteLine($"* {method}");
                    }
                }
            }
            input = Console.ReadLine()
                .Split(new[] { '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
        var methodSelection = Console.ReadLine().Split().ToList();
        if (methodSelection[1] == "all")
        {
            var methodToContain = methodSelection[0];
            foreach (var collection in collections.OrderByDescending(x => x.Value.Count())
                .ThenByDescending(x => x.Value.Min(y => y.Length)))
            {
                if (collection.Value.Contains(methodToContain))
                {
                    Console.WriteLine(collection.Key);
                    foreach (var method in collection.Value.OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($"* {method}");
                    }
                }
            }
        }
        else
        {
            var methodToContain = methodSelection[0];
            foreach (var collection in collections.OrderByDescending(x => x.Value.Count())
                .ThenByDescending(x => x.Value.Min(y => y.Length)))
            {
                if (collection.Value.Contains(methodToContain))
                {
                    Console.WriteLine(collection.Key);
                }
            }
        }
    }
}