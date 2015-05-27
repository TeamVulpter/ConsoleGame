using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleGame
{
    public class Scoreboard
    {
            public static void GenerateScoreboard()
            {
               
                Console.Write("Enter your name: ".PadLeft(55,' '));
                string newName = Console.ReadLine();
                int newScore = Score.ScoreCount;
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
                Visualization.PrintStringAtPosition(45, 12, "High Scores", ConsoleColor.Green);
                    foreach (var score in orderedScores)
                    {
                       
                        Console.WriteLine(score.PadLeft(55, ' '));
                    }
                    Visualization.PrintStringAtPosition(40, 18, "Press [enter] to exit", ConsoleColor.Red);

                File.WriteAllLines("../../Scoreboard.txt", orderedScores);
                
            }
    }
}
