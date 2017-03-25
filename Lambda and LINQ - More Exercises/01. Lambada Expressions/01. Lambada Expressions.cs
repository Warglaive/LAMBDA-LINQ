using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Lambada_Expressions
{
    public class Program
    {
        public static void Main()
        {
            var lambadaExpressions = new Dictionary<string, Dictionary<string, string>>();
            string inputLine = Console.ReadLine();
            while (inputLine != "lambada")
            {
                var inputParams = inputLine.Split(new char[] { ' ', '=', '>', '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (inputParams.Count > 1)
                {
                    var selector = inputParams[0];
                    var selectorObject = inputParams[1];
                    var property = inputParams[2];
                    if (!lambadaExpressions.ContainsKey(selector))
                    {
                        lambadaExpressions.Add(selector, new Dictionary<string, string>());
                    }
                    lambadaExpressions[selector][selectorObject] = property;
                }
                else
                {
                    lambadaExpressions = lambadaExpressions
                        .ToDictionary(selector => selector.Key, selector => selector.Value
                        .ToDictionary(selectorObject => selectorObject.Key, selectorObject => selectorObject.Key + "." + selectorObject.Value));
                }
                inputLine = Console.ReadLine();
            }
            foreach (var selector in lambadaExpressions)
            {
                foreach (var selectorObject in selector.Value)
                {
                    Console.WriteLine("{0} => {1}.{2}", selector.Key, selectorObject.Key, selectorObject.Value);
                }
            }
            //lambadaExpressions
            //    .ToList()
            //    .ForEach(selector => selector.Value.ToList()
            //    .ForEach(selectorObject => Console.WriteLine("{0} => {1}.{2}", selector.Key, selectorObject.Key, selectorObject.Value)));
        }
    }
}