using System;
using System.Linq;

namespace Example1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();               
                Console.WriteLine(GetSum(collection));
            }
        }

        public static int GetSum(int[] collection)
        {
            return collection.Sum();
        }
    }
}
