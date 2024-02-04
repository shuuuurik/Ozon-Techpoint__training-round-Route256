using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Компрессия_данных
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> answers = new List<int>();
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                int n = int.Parse(Console.ReadLine());
                int[] numbers = Console
                    .ReadLine()
                    .Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                answers.Clear();
                int currentNumber = numbers[0], delta = 0; // начинаем отсчёт для первой компрессии
                for (int j = 1; j < n; ++j) // цикл начинается с индекса 1 !!!
                {
                    if (delta >= 0 && numbers[j] == currentNumber + delta + 1)
                    {
                        delta++;
                        continue;
                    }
                    else if (delta <= 0 && numbers[j] == currentNumber + delta - 1)
                    {
                        delta--;
                        continue;
                    }
                    else
                    {
                        answers.Add(currentNumber);
                        answers.Add(delta);
                        currentNumber = numbers[j];
                        delta = 0;
                    }
                }

                answers.Add(currentNumber); // добавляем последнюю компрессию
                answers.Add(delta);

                Console.WriteLine(answers.Count); // KOMPRESSION!
                Console.WriteLine(string.Join(" ", answers));
            }
        }
    }
}
