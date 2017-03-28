using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CottageScraper
{
    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, long>();
            var input = Console.ReadLine();
            while (input != "chop chop")
            {
                var token = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var type = token[0];
                var height = long.Parse(token[1]);
                input = Console.ReadLine();
            }
            var treeType = Console.ReadLine();
            var MinLenghtPerTree = Console.ReadLine();
        }
    }

}