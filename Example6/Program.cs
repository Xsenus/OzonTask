using System;
using System.Collections.Generic;
using System.Linq;

namespace Example6
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < testCaseCount; i++)
            {
                Console.ReadLine();
                var info = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

                var countCoupe = info[0];
                var countQuery = info[1];

                var occupiedPlaces = new HashSet<int>(Enumerable.Range(1, countCoupe * 2));
                var useСompartment = new SortedSet<int>(Enumerable.Range(1, countCoupe));

                for (int j = 0; j < countQuery; j++)
                {
                    var record = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
                    if (record.Length == 2)
                    {
                        switch (record[0])
                        {
                            case 1:
                                Console.WriteLine(GetBoughtSeat(occupiedPlaces, useСompartment, record[1]));
                                break;

                            case 2:
                                Console.WriteLine(GetHandedOverSeat(occupiedPlaces, useСompartment, record[1]));
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(GetFreeSeats(occupiedPlaces, useСompartment));
                    }
                }

                Console.WriteLine();
            }
        }

        public static string GetBoughtSeat(HashSet<int> occupiedPlaces, SortedSet<int> useСompartment, int place)
        {
            if (occupiedPlaces.Contains(place))
            {
                occupiedPlaces.Remove(place);
                useСompartment.Remove((place / 2) + (place % 2));
                return "SUCCESS";
            }
            else
            {
                return "FAIL";
            }
        }

        public static string GetHandedOverSeat(HashSet<int> occupiedPlaces, SortedSet<int> useСompartment, int place)
        {
            if (!occupiedPlaces.Contains(place))
            {
                occupiedPlaces.Add(place);

                if (place % 2 == 0)
                {
                    if (occupiedPlaces.Contains(place - 1))
                    {
                        useСompartment.Add((place / 2));
                    }
                }
                else
                {
                    if (occupiedPlaces.Contains(place + 1))
                    {
                        useСompartment.Add(((place + 1) / 2));
                    }
                }
                return "SUCCESS";
            }
            else
            {
                return "FAIL";
            }
        }

        public static string GetFreeSeats(HashSet<int> occupiedPlaces, SortedSet<int> useСompartment)
        {
            var free = useСompartment.FirstOrDefault();
            if (free != 0)
            {
                useСompartment.Remove(free);
                var lastPlace = free * 2;
                occupiedPlaces.Remove(lastPlace);
                occupiedPlaces.Remove(lastPlace - 1);
                return $"SUCCESS {lastPlace - 1}-{lastPlace}";
            }

            return "FAIL";
        }        
    }
}