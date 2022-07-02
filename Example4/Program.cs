using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Example4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {                
                var countAttempts = int.Parse(Console.ReadLine());
                var dictionary = new HashSet<string>();
                for (int j = 0; j < countAttempts; j++)
                {
                    var login = Console.ReadLine();
                    Console.WriteLine(GetAnswer(login, dictionary));
                }
                Console.WriteLine();
            }
        }

        public static string GetAnswer(string login, HashSet<string> dictionary, string pattern = "[0-9a-zA-Z_][0-9a-zA-Z_-]{1,23}")
        {
            var result = default(string);

            login = login.ToLower();
            if (dictionary?.Add(login) is true
                && !login[0].Equals('-')
                && login.Equals(Regex.Matches(login, pattern)?.FirstOrDefault()?.Value))
            {
                result = "YES";
            }
            else
            {
                result = "NO";
            }
            return result;
        }
    }
}