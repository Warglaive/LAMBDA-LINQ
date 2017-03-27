using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Flatten_Dictionary
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            while (inputLine!="end")
            {
                var inputParams = inputLine.Split(' ').ToList();
                if (inputParams[0] != "flatten")
                {
                    var key = inputParams[0];
                    var innerKey = inputParams[1];
                    var innerValue = inputParams[2];
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, new Dictionary<string, string>());
                    }
                        dictionary[key][innerKey] = innerValue;
                }
                else
                {
                    var key = inputParams[1];
                    dictionary[key] = dictionary[key].ToDictionary(x => x.Key + x.Value, x => "flattened");
                }
                inputLine = Console.ReadLine();
            }
            var orderedDictionary = new Dictionary<string, Dictionary<string, string>>()
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var entry in dictionary.OrderByDescending(x => x.Key.Length)) 
            {
                Console.WriteLine("{0}", entry.Key);
                Dictionary<string, string> orderedInnerDictionary = entry.Value
                    .Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);
                Dictionary<string, string> flattenedValues =
                    entry.Value
                    .Where(x => x.Value == "flattened")
                    .ToDictionary(x => x.Key, x => x.Value);
                int count = 0;
                foreach (var innerEntry in orderedInnerDictionary)
                {
                    count++;
                    Console.WriteLine("{0}. {1} - {2}", count, innerEntry.Key, innerEntry.Value);
                }
                foreach (var flattened in flattenedValues)
                {
                    count++;
                    Console.WriteLine("{0}. {1}",count, flattened.Key);
                }
            }
        }
    }
}