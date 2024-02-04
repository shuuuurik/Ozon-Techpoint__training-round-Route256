using System;
using System.Linq;
using System.Text;

namespace _07_Печать_документа
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                int totalPages = int.Parse(Console.ReadLine());
                string[] commands = Console
                    .ReadLine()
                    .Split(',');
                bool[] pages = new bool[totalPages];
                for (int j = 0; j < totalPages; ++j) //иНиЦИаЛиЗАцИЯ???
                    pages[j] = false;

                foreach (string command in commands)
                {
                    if (command.Contains('-'))
                    {
                        int[] borders = command
                            .Split('-')
                            .Select(int.Parse)
                            .ToArray();
                        for (int j = borders[0] - 1; j <= borders[1] - 1; ++j)
                            pages[j] = true;
                    }
                    else
                        pages[int.Parse(command) - 1] = true;
                }
                StringBuilder sb = new StringBuilder("");
                int left = -1;
                for (int j = 0; j < totalPages; ++j)
                {
                    if (left == -1 && !pages[j])
                        left = j;
                    else if (left != -1 && pages[j]) // после некоторого кол-ва ненапечатанных страниц встречена страница на печать
                    {
                        if (j == left + 1) // если после ненапечатанной сразу идёт страница на печать
                            sb.Append($"{j},");
                        else
                            sb.Append($"{left + 1}-{j},");
                        left = -1;
                    }
                }
                if (left != -1) // если последняя страница была не на печать
                    if (left == totalPages - 1)
                        sb.Append($"{totalPages}");
                    else
                        sb.Append($"{left + 1}-{totalPages}");
                Console.WriteLine(sb.ToString().TrimEnd(','));
            }
        }
    }
}
