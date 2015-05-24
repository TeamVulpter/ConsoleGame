using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleGame
{
    public class Scoreboard
    {
            public static void GenerateScoreboard(int scoreCount)
            {
                Console.WriteLine("Enter your name: ");
                string newName = Console.ReadLine();
                int newScore = scoreCount;
                string newData = newName + ":" + newScore;

                string[] scores = File.ReadAllLines("../../Scoreboard.txt");
                var orderedScores = scores.OrderByDescending(x => int.Parse(x.Split(':')[1]));

                for (int i = 0; i < scores.Length; i++)
                {
                    var lastScore = Regex.Match(scores[4], @"\d+").Value;
                    int extractedScore = Int32.Parse(lastScore);
                    if (newScore > extractedScore)
                    {
                        scores[4] = newData;
                    }
                }

                foreach (var score in orderedScores)
                {
                    Console.WriteLine(score.PadLeft(10, ' '));
                }

                File.WriteAllLines("../../Scoreboard.txt", orderedScores);
            }
    }
}
