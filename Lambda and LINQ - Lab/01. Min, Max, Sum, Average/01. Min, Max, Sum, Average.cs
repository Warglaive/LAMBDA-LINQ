using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Min__Max__Sum__Average
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                result[i] = currentNumber;
            }
            Console.WriteLine("Sum = {0}", result.Sum());
            Console.WriteLine("Min = {0}", result.Min());
            Console.WriteLine("Max = {0}", result.Max());
            Console.WriteLine("Average = {0}", result.Average());
        }
    }
}
