using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery
{
    public class Program
    {
        static void Main(string[] args)
        {
            byte totalPlayers;
            bool isNumber;
            do
            {
                Console.WriteLine("How many players gona play this game ? (Limit 10 players)");
                Console.Write("Type number and press enter: ");

                isNumber = byte.TryParse(Console.ReadLine(), out totalPlayers);

                Console.Clear();

                if (totalPlayers > 0 && totalPlayers <= 10)
                    break;
                ConsoleHelper.WriteLineColerful("Wrong input try again", ConsoleColor.Red);
            } while (true);

            Dictionary<string, List<int>> players = AddPlayersToDictionary(totalPlayers);

            WritePlayersNumbers(players);
            ConsoleHelper.WriteLineInTypingStyle("Generating lucky numbers until winner(s) occurs :\n ",50, ConsoleColor.Blue);

            var points = new Dictionary<string, int>();
            var playersNames = players.Keys.ToList();
            points = playersNames.ToDictionary(x => x, x => 0);

            Queue<int> luckyNumbersSpot = NumbersGenerator.GenerateQueueWithUniqueNumbers(50, 1, 50);

            bool loopCondition = true;

            while (loopCondition)
            {
                int luckyNumber = luckyNumbersSpot.Dequeue();

                ConsoleHelper.WriteInTypingStyle(luckyNumber + " ", 400, ConsoleColor.Green);

                foreach (KeyValuePair<string, List<int>> pair in players)
                {
                    foreach (int number in pair.Value) // Adding points
                    {
                        if (luckyNumber == number)
                            points[pair.Key] += 1;
                    }
                }
                foreach (KeyValuePair<string, int> item in points) // Identifying winner
                {
                    if (item.Value == PointsToWin)
                    {
                        ConsoleHelper.WriteLineColerful($"\n\nWinner - {item.Key}", ConsoleColor.Blue);
                        loopCondition = false;
                    }
                }
            }
            Console.ReadLine();
        }

        private static void WritePlayersNumbers(Dictionary<string, List<int>> playersDictionary)
        {
            foreach (KeyValuePair<string, List<int>> item in playersDictionary)
            {
                ConsoleHelper.WriteColerful(item.Key, ConsoleColor.Blue);
                Console.Write(" lucky numbers are: ");
                foreach (int luckyNumber in item.Value)
                {
                    ConsoleHelper.WriteInTypingStyle(luckyNumber + " ", 200, ConsoleColor.Green);
                }
                Console.WriteLine("\n");
            }
        }

        private static Dictionary<string, List<int>> AddPlayersToDictionary(int totalPlayers)
        {
            var players = new Dictionary<string, List<int>>();
            int counter = 0;

            do
            {
                Console.Write($"Enter player {counter + 1} name (Max 15 letters): ");

                string playerName = Console.ReadLine();

                bool isNameWrong = players.ContainsKey(playerName) || String.IsNullOrWhiteSpace(playerName) || playerName.Length > 15;

                if (!isNameWrong)
                {
                    players.Add(playerName, NumbersGenerator.GenerateListWithUniqueNumbers(3, 1, 50));
                    counter++;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    string errorMessage = players.ContainsKey(playerName) ? "Name exists please type another name"
                                                                          : "Wrong input try again";
                    ConsoleHelper.WriteLineColerful(errorMessage, ConsoleColor.Red);
                }
            } while (counter != totalPlayers);

            return players;
        }
        private const byte PointsToWin = 3;
    }
}


