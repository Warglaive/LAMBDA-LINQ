using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace _01.Register_Users
{
    public class Program
    {
        public static void Main()
       {
            var input = Console.ReadLine();
            var users = new Dictionary<string, DateTime>();
            while (input != "end") 
            {
                var token = input.Split(new char[] { '-', '>', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = token[0];
                var date = DateTime.ParseExact(token[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                users[name] = date;
                input = Console.ReadLine();
            }
            var result = users.Reverse().OrderBy(u => u.Value).Take(5).OrderByDescending(y => y.Value);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}