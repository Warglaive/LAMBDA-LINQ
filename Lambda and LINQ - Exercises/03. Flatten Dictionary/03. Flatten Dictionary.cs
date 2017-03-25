using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Flatten_Dictionary
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var KeyValue = new Dictionary<string, string>();
            while (input != "end") 
            {
                var token = input.Split(' ').ToList();
                var key = token[0];
                var innerKey = token[1];
                var innerValue = token[2];



                input = Console.ReadLine();
            }
        }
    }
}
