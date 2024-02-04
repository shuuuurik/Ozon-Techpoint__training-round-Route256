using System;
using System.Linq;

namespace _02_Проверка_Даты
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                int[] dateParts = Console
                    .ReadLine()
                    .Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                if (dateParts[1] == 2 && ((dateParts[2] % 4 == 0 && (dateParts[2] % 100 != 0 || dateParts[2] % 400 == 0) && dateParts[0] > 29) // високосный
                                      || ((dateParts[2] % 4 != 0 || (dateParts[2] % 100 == 0 && dateParts[2] % 400 != 0)) && dateParts[0] > 28)) // невисокосный
                    || dateParts[1] == 4 && dateParts[0] > 30
                    || dateParts[1] == 6 && dateParts[0] > 30
                    || dateParts[1] == 9 && dateParts[0] > 30
                    || dateParts[1] == 11 && dateParts[0] > 30)
                    Console.WriteLine("NO");
                else
                    Console.WriteLine("YES");

                //Console.WriteLine(DateTime.TryParse($"{dateParts[0]}.{dateParts[1]}.{dateParts[2]}", out _) ? "YES" : "NO");
            }

            #region Чтение и запись в файл
            /*
            string srcpath = @"D:\university\Ozon Techpoint\2";
            string destpath = @"D:\university\Ozon Techpoint\out.txt";
            using (StreamReader reader = new StreamReader(srcpath))
            {
                using (StreamWriter writer = new StreamWriter(destpath))
                {
                    int t1 = int.Parse(reader.ReadLine());
                    for (int i = 0; i < t1; ++i)
                    {
                        int[] dateParts = reader
                            .ReadLine()
                            .Split()
                            .Select(x => int.Parse(x))
                            .ToArray();

                        if (dateParts[1] == 2 && ((dateParts[2] % 4 == 0 && (dateParts[2] % 100 != 0 || dateParts[2] % 400 == 0) && dateParts[0] > 29) // високосный
                                              || ((dateParts[2] % 4 != 0 || (dateParts[2] % 100 == 0 && dateParts[2] % 400 != 0)) && dateParts[0] > 28)) // невисокосный
                            || dateParts[1] == 4 && dateParts[0] > 30
                            || dateParts[1] == 6 && dateParts[0] > 30
                            || dateParts[1] == 9 && dateParts[0] > 30
                            || dateParts[1] == 11 && dateParts[0] > 30)
                            writer.WriteLine("NO");
                        else
                            writer.WriteLine("YES");

                        //writer.Write(DateTime.TryParse($"{dateParts[0]}.{dateParts[1]}.{dateParts[2]}", out _) ? "YES" : "NO");
                    }
                }
            }
            */
            #endregion Чтение и запись в файл
        }
    }
}
