using System;

namespace _04_Битва_за_кондиционер
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                int l = 15, r = 30;
                bool flag = false;
                int n = int.Parse(Console.ReadLine());
                for (int j = 0; j < n; ++j)
                {
                    if (flag)
                    {
                        Console.ReadLine();
                        Console.WriteLine("-1");
                        continue;
                    }
                    string[] strings = Console
                        .ReadLine()
                        .Split();
                    if (strings[0] == ">=")
                    {
                        int num = int.Parse(strings[1]);
                        if (num > l)
                            l = num;
                    }
                    else if (strings[0] == "<=")
                    {
                        int num = int.Parse(strings[1]);
                        if (num < r)
                            r = num;
                    }

                    if (l <= r)
                        Console.WriteLine(l);
                    else
                    {
                        flag = true;
                        Console.WriteLine("-1");
                    }
                }
            }
        }
    }
}
