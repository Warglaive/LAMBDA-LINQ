using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Ordered_Banking_System
{
    public class Program
    {
        public static void Main()
        {
            var inputLines = Console.ReadLine();
            var result = new Dictionary<string, Dictionary<string, decimal>>();
            while (inputLines != "end")
            {
                if (inputLines.Length > 1)
                {
                    var token = inputLines.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var bank = token[0];
                    var account = token[1];
                    var balance = decimal.Parse(token[2]);
                    if (!result.ContainsKey(bank))
                    {
                        result.Add(bank, new Dictionary<string, decimal>());
                    }

                    if (!result[bank].ContainsKey(account))
                    {
                        result[bank].Add(account, 0);
                    }
                    result[bank][account] += balance;
                    
                    inputLines = Console.ReadLine();
                }
            }
            foreach (var bank in result.OrderByDescending(bank => bank.Value.Sum(acc => acc.Value))
                .ThenByDescending(bank => bank.Value.Max(acc => acc.Value))) 
            {
                foreach (var account in bank.Value.OrderByDescending(account => account.Value)) 
                {
                    Console.WriteLine("{1} -> {2} ({0})", bank.Key, account.Key, account.Value);
                }
            }
            //result.OrderByDescending(bank => bank.Value.Sum(acc => acc.Value))
            //    .ThenByDescending(bank => bank.Value.Max(acc => acc.Value))
            //    .ToList()
            //    .ForEach(bank => bank.Value.OrderByDescending(acc => acc.Value)
            //    .ToList()
            //    .ForEach(acc => Console.WriteLine("{0} -> {1} ({2})", acc.Key, acc.Value, bank.Key)));
        }
    }
}