using System;
using System.Collections.Generic;
using System.Linq;
namespace _02_DefaultValues
{
    public class DefaltValues
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var store = new Dictionary<string, string>();
            while (command != "end") 
            {
                var token = command.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var key = token[0];
                var value = token[1];
                store[key] = value;
                command = Console.ReadLine();
            }
            var defaultValue = Console.ReadLine();
            var unchangedValues = store.Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);
            var changedValues = store.Where(x => x.Value == "null")
                .ToDictionary(x => x.Key, x => defaultValue);
            foreach (var item in unchangedValues)
            {
                Console.WriteLine($"{item.Key} <-> {item.Value}");
            }
            foreach (var item in changedValues)
            {
                Console.WriteLine($"{item.Key} <-> {item.Value}");
            }
        }
    }
}