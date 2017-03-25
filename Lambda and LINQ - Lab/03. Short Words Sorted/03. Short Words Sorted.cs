using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Short_Words_Sorted
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower().Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }
            , StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(string.Join(", ", text.Where(x => x.Length < 5).Distinct().OrderBy(x=>x)));
        }
    }
}