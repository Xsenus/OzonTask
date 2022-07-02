using System;
using System.Linq;

namespace Example2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                var count = int.Parse(Console.ReadLine());
                var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

                var sum = GetValue(collection);
                Console.WriteLine(sum);
            }
        }

        public static int GetValue(int[] collection)
        {
            var sum = 0;
            var collectionProduct = collection.GroupBy(g => g);
            foreach (var item in collectionProduct)
            {
                var countItem = item.Count() - (item.Count() / 3);
                sum += countItem * item.Key;
            }

            return sum;
        }
    }
}