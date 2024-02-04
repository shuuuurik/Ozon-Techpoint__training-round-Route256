using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_3_Покер
{
    class Program
    {
        static void Main(string[] args)
        {
            // Заготовки
            List<char> allSuits = new List<char> { 'S', 'C', 'D', 'H' }; // все масти
            Dictionary<char, int> values = new Dictionary<char, int> // все значения
            {
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'T', 10 },
                { 'J', 11 },
                { 'Q', 12 },
                { 'K', 13 },
                { 'A', 14 }
            };
            List<string> allCards = new List<string> // все карты
            {
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "TS", "JS", "QS", "KS", "AS",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "TC", "JC", "QC", "KC", "AC",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "TD", "JD", "QD", "KD", "AD",
                "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "TH", "JH", "QH", "KH", "AH"
            };

            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; ++i)
            {
                int counter = 0;
                List<string> answers = new List<string>();
                List<string> playersCards = new List<string>(); 
                int n = int.Parse(Console.ReadLine());
                string[] myCards = Console
                        .ReadLine()
                        .Split(' ');
                playersCards.Add(myCards[0]);
                playersCards.Add(myCards[1]);
                List<List<string>> players = new List<List<string>>();
                for (int j = 1; j < n; ++j)
                {
                    string[] cards = Console
                        .ReadLine()
                        .Split(' ');
                    playersCards.Add(cards[0]);
                    playersCards.Add(cards[1]);
                    players.Add(new List<string> { cards[0], cards [1] });
                }

                // пошла жесткая логика

                // 1. Если обе наши карты одного значения
                if (myCards[0][0] == myCards[1][0]) 
                {
                    // 1. 1. Пробуем собрать сет. Для этого проверяем, содержат ли наши карты одно значение.
                    char myValue = myCards[0][0]; // значение
                    List<char> mySuits = new List<char> { myCards[0][1], myCards[1][1] };
                    List<char> anotherSuits = allSuits.Except(mySuits).ToList();

                    // Проверяем, нет ли у других игроков карт с нужным нам значением (ищем это значение среди двух оставшихся мастей)
                    string card1 = new string(new[] { myValue, anotherSuits[0] });
                    if (!playersCards.Contains(card1))
                    {
                        counter++;
                        answers.Add(new string(new []{ myValue, anotherSuits[0] }));
                    }
                    string card2 = new string(new[] { myValue, anotherSuits[1] });
                    if (!playersCards.Contains(card2))
                    {
                        counter++;
                        answers.Add(new string(new[] { myValue, anotherSuits[1] }));
                    }
                    // Если собрали сет, то гарантированно победили

                    // 1. 2. Пробуем победить через пару.
                    // Перебираем все оставшиеся в колоде карты в поисках подходящих нам для победы через пару
                    foreach (string card in allCards.Except(playersCards))
                    {
                        bool flag = false;
                        foreach(List<string> player in players)
                        {
                            if ( (player[0][0] == card[0] && player[1][0] == card[0]) // Какой-то игрок собрал сет
                                || (values[card[0]] > values[myValue] && (player[0][0] == card[0] || player[1][0] == card[0])) // Какой-то игрок собрал пару со значением больше нашего
                                || (player[0][0] == player[1][0] && values[player[0][0]] > values[myValue])) // У какого-то игрока уже есть пара старше нашей
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag && !answers.Contains(card)) // Никто из игроков не может перебить нас сетом или старшей парой
                        {
                            counter++;
                            answers.Add(card);
                        }
                    }
                }
                else // 2. Если наши карты разного значения
                {
                    // 2. 1. Пробуем собрать пару. Для этого проверяем, осталась ли в колоде карта с таким же значением, как одна из наших карт.
                    foreach (string myCard in myCards)
                    {
                        char myValue = myCard[0];
                        List<char> anotherSuits = allSuits.Except(new List<char> { myCard[0] }).ToList(); // Остальные 3 масти
                        foreach (char suit in anotherSuits) // Перебираем другие 3 карты с этим же значением
                        {
                            string card = new string(new[] { myValue, suit });
                            if (playersCards.Contains(card)) // Такую карту уже кто-то взял
                                continue;
                            else
                            {
                                bool flag = false;
                                foreach (List<string> player in players)
                                {
                                    if ((player[0][0] == card[0] && player[1][0] == card[0]) // Какой-то игрок собрал сет
                                        || (player[0][0] == player[1][0] && values[player[0][0]] > values[myValue])) // У кого-то есть пара старше нашей
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (!flag && !answers.Contains(card)) // Никто из игроков не может перебить нас сетом
                                {
                                    counter++;
                                    answers.Add(card);
                                }
                            }
                        }
                    }

                    // 2. 2. Перебираем все карты в поисках подходящих нам для победы через старшую карту
                    foreach (string card in allCards.Except(playersCards))
                    {
                        // Находим старшую карту среди своих двух
                        string myStrongestCard = values[myCards[0][0]] > values[myCards[1][0]] ? myCards[0] : myCards[1];
                        char myStrongestValue = myStrongestCard[0];
                        // Находим старшее значение среди своих двух карт и потенциально выложенной на стол
                        char strongestValue = values[myStrongestValue] > values[card[0]] ? myStrongestValue : card[0];

                        bool flag = false;
                        foreach (List<string> player in players)
                        {
                            if ((player[0][0] == card[0] && player[1][0] == card[0]) // Какой-то игрок собрал сет
                                || (player[0][0] == player[1][0] || player[0][0] == card[0] || player[1][0] == card[0]) // Какой-то игрок собрал пару
                                || (values[player[0][0]] > values[strongestValue] || values[player[1][0]] > values[strongestValue])) // У кого-то есть карта, старше нашей
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag && !answers.Contains(card)) // Никто из игроков не может перебить нас сетом, парой или старшей картой
                        {
                            counter++;
                            answers.Add(card);
                        }
                    }
                }

                Console.WriteLine(counter);
                if (counter != 0)
                    foreach (string answer in answers)
                        Console.WriteLine(answer);
            }
        }
    }
}
