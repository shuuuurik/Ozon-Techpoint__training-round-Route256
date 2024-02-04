using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_Автомобильные_номера
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex1 = new Regex(@"^[A-Z][0-9]{2}[A-Z]{2}$", RegexOptions.Compiled);
            Regex regex2 = new Regex(@"^[A-Z][0-9][A-Z]{2}$", RegexOptions.Compiled);
            List<string> answers = new List<string>();

            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                string str = Console.ReadLine();
                answers.Clear();
                while (str.Length >= 4)
                {
                    string fourChars = str.Substring(0, 4);
                    if (regex2.IsMatch(fourChars))
                    {
                        answers.Add(fourChars);
                        str = str[4..];
                        continue;
                    }

                    if (str.Length == 4)
                        break;

                    string fiveChars = str.Substring(0, 5);
                    if (regex1.IsMatch(fiveChars))
                    {
                        answers.Add(fiveChars);
                        str = str[5..];
                        continue;
                    }
                    break;
                }
                Console.WriteLine(str.Length > 0 ? "-" : string.Join(" ", answers));
            }
        }
    }
}
