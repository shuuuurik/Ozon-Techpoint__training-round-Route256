using System;
using System.Collections.Generic;
using System.IO;

namespace _06_Терминал
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Чтение_из_файла
            /*
            string srcpath = @"D:\university\Ozon Techpoint\12";
            string destpath = @"D:\university\Ozon Techpoint\out.txt";
            using (StreamReader reader = new StreamReader(srcpath))
            {
                using (StreamWriter writer = new StreamWriter(destpath))
                {
                    List<string> answers = new List<string>();
                    int t = int.Parse(reader.ReadLine());
                    for (int i = 0; i < t; ++i)
                    {
                        answers.Clear();
                        answers.Add("");
                        string commandString = reader.ReadLine();
                        int currStringIndex = 0, currIndex = 0;
                        while (commandString.Length > 0)
                        {
                            char command = commandString.Substring(0, 1)[0];
                            commandString = commandString[1..];
                            switch (command)
                            {
                                case 'L':
                                    if (currIndex > 0)
                                        currIndex--;
                                    break;
                                case 'R':
                                    if (currIndex < answers[currStringIndex].Length)
                                        currIndex++;
                                    break;
                                case 'U':
                                    if (currStringIndex != 0)
                                    {
                                        currStringIndex--;
                                        if (currIndex > answers[currStringIndex].Length)
                                            currIndex = answers[currStringIndex].Length;
                                    }
                                    break;
                                case 'D':
                                    if (currStringIndex != answers.Count - 1)
                                    {
                                        currStringIndex++;
                                        if (currIndex > answers[currStringIndex].Length)
                                            currIndex = answers[currStringIndex].Length;
                                    }
                                    break;
                                case 'B':
                                    currIndex = 0;
                                    break;
                                case 'E':
                                    currIndex = answers[currStringIndex].Length;
                                    break;
                                case 'N':
                                    string currString = answers[currStringIndex];
                                    string shiftedString = currString.Substring(currIndex);

                                    //if (currIndex > 0)
                                    answers[currStringIndex] = currString.Substring(0, currIndex);
                                    if (currStringIndex < answers.Count - 1)
                                        answers.Insert(currStringIndex + 1, shiftedString);
                                    else
                                        answers.Add(shiftedString);
                                    currStringIndex++;
                                    currIndex = 0;
                                    break;
                                default:
                                    currString = answers[currStringIndex];
                                    answers[currStringIndex] = currString.Substring(0, currIndex) + command + currString.Substring(currIndex); //(currIndex == currString.Length ? "" : currString.Substring(currIndex + 1));
                                    currIndex++;
                                    break;
                            }
                        }
                        writer.WriteLine(string.Join("\n", answers));
                        writer.WriteLine("-");
                    } 
                }
            }
            */
            #endregion

            List<string> answers = new List<string>();
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                answers.Clear();
                answers.Add("");
                string commandString = Console.ReadLine();
                int currStringIndex = 0, currIndex = 0;
                while (commandString.Length > 0)
                {
                    char command = commandString.Substring(0, 1)[0];
                    commandString = commandString[1..];
                    switch (command)
                    {
                        case 'L':
                            if (currIndex > 0)
                                currIndex--;
                            break;
                        case 'R':
                            if (currIndex < answers[currStringIndex].Length)
                                currIndex++;
                            break;
                        case 'U':
                            if (currStringIndex != 0)
                            {
                                currStringIndex--;
                                if (currIndex > answers[currStringIndex].Length)
                                    currIndex = answers[currStringIndex].Length;
                            }
                            break;
                        case 'D':
                            if (currStringIndex != answers.Count - 1)
                            {
                                currStringIndex++;
                                if (currIndex > answers[currStringIndex].Length)
                                    currIndex = answers[currStringIndex].Length;
                            }
                            break;
                        case 'B':
                            currIndex = 0;
                            break;
                        case 'E':
                            currIndex = answers[currStringIndex].Length;
                            break;
                        case 'N':
                            string currString = answers[currStringIndex];
                            string shiftedString = currString.Substring(currIndex);

                            answers[currStringIndex] = currString.Substring(0, currIndex);
                            if (currStringIndex < answers.Count - 1)
                                answers.Insert(currStringIndex + 1, shiftedString);
                            else
                                answers.Add(shiftedString);
                            currStringIndex++;
                            currIndex = 0;
                            break;
                        default:
                            currString = answers[currStringIndex];
                            answers[currStringIndex] = currString.Substring(0, currIndex) + command + currString.Substring(currIndex);
                            currIndex++;
                            break;
                    }
                }
                Console.WriteLine(string.Join("\n", answers));
                Console.WriteLine("-");
            }
        }
    }
}
