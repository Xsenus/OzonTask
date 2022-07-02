using System;
using System.Collections.Generic;
using System.Linq;

namespace Example5
{
    public class Program
    {
        public class Book
        {
            public Book(string name)
            {
                Name = name;
                Phones = new List<string>();
            }

            public int PhoneCount => Phones.Count;
            public string Name { get; private set; }
            public List<string> Phones { get; private set; }

            public void AddPhone(string phone)
            {
                if (Phones.Contains(phone))
                {
                    if (Phones.IndexOf(phone) != 0)
                    {
                        Phones.Remove(phone);
                        Phones.Insert(0, phone);
                    }
                }
                else
                {
                    Phones.Insert(0, phone);
                }

                if (PhoneCount > 5)
                {
                    Phones.RemoveAt(5);
                }
            }

            public override string ToString()
            {
                return $"{Name}: {PhoneCount} {string.Join(' ', Phones)}".Trim();
            }
        }

        static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                var countAttempts = int.Parse(Console.ReadLine());

                var directoryClass = new HashSet<Book>();
                for (int j = 0; j < countAttempts; j++)
                {
                    var record = Console.ReadLine().Split(' ').ToArray();
                    ChangeBook(directoryClass, record);
                }
                Console.WriteLine(string.Join("\r\n", directoryClass.OrderBy(o => o.Name)));
                Console.WriteLine();

                var directoryDictionary = new Dictionary<string, List<string>>();
                for (int j = 0; j < countAttempts; j++)
                {
                    var record = Console.ReadLine().Split(' ').ToArray();
                    ChangeBook(directoryDictionary, record);
                }
                foreach (var item in directoryDictionary.OrderBy(o => o.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value.Count} {string.Join(" ", item.Value)}");
                }
                Console.WriteLine();
            }
        }

        public static void ChangeBook(Dictionary<string, List<string>> directory, string[] record)
        {
            if (directory.TryGetValue(record[0], out List<string> listValue))
            {
                if (listValue.Contains(record[1]))
                {
                    if (listValue.IndexOf(record[1]) != 0)
                    {
                        listValue.Remove(record[1]);
                        listValue.Insert(0, record[1]);
                    }
                }
                else
                {
                    listValue.Insert(0, record[1]);
                }

                if (listValue.Count > 5)
                {
                    listValue.RemoveAt(5);
                }
            }
            else
            {
                listValue = new List<string>();
                listValue.Add(record[1]);
                directory.Add(record[0], listValue);
            }
        }

        public static void ChangeBook(HashSet<Book> directory, string[] record)
        {
            var book = directory.FirstOrDefault(f => f.Name.Equals(record[0]));
            if (book is null)
            {
                book = new Book(record[0]);
                directory.Add(book);
            }
            book.AddPhone(record[1]);
        }
    }
}