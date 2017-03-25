using System;
using System.Linq;
namespace _04.Fold_and_Sum
{
    public class Program
    {
        public static void Main()
        {
            var result = 0;
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = numbers.Length / 4;
            var leftPart = numbers.Take(k).Reverse().ToList();
            var rightPart = numbers.Reverse().Take(k).ToList();
            var firstRow = leftPart.Concat(rightPart).ToList();
            var secondRow = numbers.Skip(k).Take(2 * k).ToList();
            for (int i = 0; i < secondRow.Count; i++)
            {
                result = firstRow[i] + secondRow[i];
                Console.Write("{0} ",result);
            }
            Console.WriteLine();
        }
    }
}