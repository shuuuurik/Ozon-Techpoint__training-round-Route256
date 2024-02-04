using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Морской_Бой
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 1; i <= t; ++i)
            {
                //string str = Console.ReadLine().Trim();
                //string[] ships = str.Split(' ');
                int[] ships = Console
                    .ReadLine()
                    .Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                //var dictionary = new Dictionary<int, int>() {
                //    { 1, 0 },
                //    { 2, 0 },
                //    { 3, 0 },
                //    { 4, 0 }
                //};
                List<int> types = new List<int>() { 0, 0, 0, 0 };
                foreach (int ship in ships)
                    types[ship - 1]++;
                //dictionary[int.Parse(ship)]++;

                //Console.WriteLine(dictionary[1] == 4 && dictionary[2] == 3 && dictionary[3] == 2 && dictionary[4] == 1 ? "YES" : "NO");
                Console.WriteLine(types[0] == 4 && types[1] == 3 && types[2] == 2 && types[3] == 1 ? "YES" : "NO");
            }
        }
    }
}
