using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Анализ_игрового_поля
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int k = 0; k < t; ++k)
            {
                List<int> answers = new List<int>(); // список глубин вложенностей всех рамок

                string[] sizes = Console
                    .ReadLine()
                    .Split(' ');
                int n = int.Parse(sizes[0]);
                int m = int.Parse(sizes[1]);
                int[][] field = new int[n][]; // игровое поле

                // Инициализация игрового поля значениями 0 (в ячейке нет рамки) и 1 (в ячейке есть рамка)
                for (int i = 0; i < n; ++i) // перебор по строкам
                {
                    // Построчное получение значений, конвертация символов ('.' -> 0, '*' -> 1), построчное заполнение двумерного массива
                    field[i] = Console
                        .ReadLine()
                        .ToCharArray()
                        .Select(x => x == '*' ? 1 : 0)
                        .ToArray();
                }
                for (int i = 0; i < n; ++i) // перебор по строкам
                {
                    int level = 0;
                    for (int j = 0; j < m; ++j) // перебор ячеек по столбцам внутри строки
                    {
                        // левая стенка рамки, исключая верхний и нижний углы
                        if (field[i][j] == 1 && ((j == 0 || field[i][j-1] == 0) && j < m - 1 && field[i][j + 1] == 0)) 
                        {
                            ++level;
                        }

                        // правый верхний угол рамки
                        if (field[i][j] == 1 && j > 0 && field[i][j-1] == 1 && i < n - 1 && field[i+1][j] == 1) 
                        {
                            for(int _i = i; _i < n && field[_i][j] == 1 ; ++_i) // меняем всю правую стенку рамки на -1, включая углы
                            {
                                field[_i][j] = -1;
                            }
                        }

                        // правая стенка рамки, исключая верхний и нижний углы
                        if (field[i][j] == -1 && field[i][j-1] == 0)
                        {
                            --level;
                        }

                        // правый нижний угол рамки
                        if (field[i][j] == -1 && i > 0 && field[i-1][j] == -1 && j > 0 && field[i][j-1] == 1) 
                        {
                            answers.Add(level);
                        }
                    }
                }

                //Array.Sort(answers.ToArray());
                Console.WriteLine(string.Join(' ', answers.OrderBy(i => i)));
            }
        }
    }
}
