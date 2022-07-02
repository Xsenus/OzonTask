using System;
using System.Linq;

namespace Example3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = default(string);

            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                Console.ReadLine();
                var size = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
                var n = size[0];
                var m = size[1];
                var array = new int[n][];

                for (int j = 0; j < n; j++)
                {
                    var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
                    array[j] = collection;
                }

                var countClick = int.Parse(Console.ReadLine());
                var clickCollection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
                array = GetSortArray(array, clickCollection);
                result += ArrayPrint(array, n, m);
            }

            Console.WriteLine(result);
        }

        public static int[][] GetSortArray(int[][] array, int[] clickCollection)
        {
            for (int c = 0; c < clickCollection.Count(); c++)
            {
                var column = clickCollection[c] - 1;
                array = array.OrderBy(x => x[column]).ToArray();
            }

            return array;
        }

        private static string ArrayPrint(int[][] array, int n, int m)
        {
            var result = default(string);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result += $"{array[i][j]} ";
                }
                result += Environment.NewLine;
            }
            result += Environment.NewLine;
            return result;
        }
    }
}