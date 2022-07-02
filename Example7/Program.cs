using System;
using System.Collections.Generic;
using System.Linq;

namespace Example7
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                var dictyonary = new Dictionary<string, List<string>>();
                var assemblyOrder = new HashSet<string>();

                Console.ReadLine();
                var countModul = int.Parse(Console.ReadLine());
                for (int j = 0; j < countModul; j++)
                {
                    var record = Console.ReadLine().Replace(":", " ").Split(' ').ToArray();
                    dictyonary.Add(record[0], record.Skip(1).Where(w => !string.IsNullOrWhiteSpace(w)).ToList());
                }

                var countAssemblyOrder = int.Parse(Console.ReadLine());
                for (int j = 0; j < countAssemblyOrder; j++)
                {
                    var module = Console.ReadLine();
                    Console.WriteLine(GetPosition(dictyonary, assemblyOrder, module));
                }

                Console.WriteLine();
            }
        }

        public static string GetPosition(Dictionary<string, List<string>> dictyonary, HashSet<string> assemblyOrders, string assemblyOrder)
        {
            var result = GetListAssemblyOrder(dictyonary, assemblyOrders, assemblyOrder);
            return $"{result.Count} {string.Join(" ", result)}";
        }

        private static List<string> GetListAssemblyOrder(Dictionary<string, List<string>> dictyonary, HashSet<string> assemblyOrders, string assemblyOrder)
        {
            if (assemblyOrders.Contains(assemblyOrder))
            {
                return new List<string>();
            }

            var result = new List<string>();

            var list = dictyonary[assemblyOrder];
            list.Reverse();

            foreach (var currentAssemblyOrder in list)
            {
                if (!assemblyOrders.Contains(currentAssemblyOrder))
                {
                    result.AddRange(GetListAssemblyOrder(dictyonary, assemblyOrders, currentAssemblyOrder));
                    assemblyOrders.Add(currentAssemblyOrder);
                }
            }

            result.Add(assemblyOrder);
            assemblyOrders.Add(assemblyOrder);
            return result;
        }
    }
}