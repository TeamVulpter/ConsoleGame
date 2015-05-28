using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Map
    {
        public static Player player = new Player(40 - 2, 40 / 2, '@', ConsoleColor.Red);
        
        public static void UpdateMap()
        {
            int[,] matrix = new int[40, 40];

            DrawField(matrix);

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        if (matrix[player.Y - 1, player.X] != 1)
                        {
                            if (matrix[player.Y - 1, player.X] > 1 && matrix[player.Y - 1, player.X] != 8)
                            {
                                AddScores(player.Y - 1, player.X, matrix);
                                AddLife(player.Y - 1, player.X, matrix);
                                matrix[player.Y - 1, player.X] = 0;
                            }
                            else if (matrix[player.Y - 1, player.X] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            
                            Visualization.PrintCharMatrixAtPosition(player.Y, player.X, ' ');
                            player.Y--;
                        }
                        
                    }

                    if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (matrix[player.Y + 1, player.X] != 1)
                        {
                            if (matrix[player.Y + 1, player.X] > 1 && matrix[player.Y + 1, player.X] != 8)
                            {
                                AddScores(player.Y + 1, player.X, matrix);
                                AddLife(player.Y + 1, player.X, matrix);
                                matrix[player.Y + 1, player.X] = 0;
                            }
                            else if (matrix[player.Y + 1, player.X] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharMatrixAtPosition(player.Y, player.X, ' ');
                            player.Y++;
                        }
                      
                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (matrix[player.Y, player.X - 1] != 1)
                        {
                            if (matrix[player.Y, player.X - 1] > 1 && matrix[player.Y, player.X - 1] != 8)
                            {
                                AddScores(player.Y, player.X - 1, matrix);
                                AddLife(player.Y, player.X - 1, matrix);
                                matrix[player.Y, player.X - 1] = 0;
                            }
                            else if (matrix[player.Y, player.X - 1] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharMatrixAtPosition(player.Y, player.X, ' ');
                            player.X--;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (matrix[player.Y, player.X + 1] != 1)
                        {
                            if (matrix[player.Y, player.X + 1] > 1 && matrix[player.Y, player.X + 1]!=8)
                            {
                                AddScores(player.Y, player.X + 1, matrix);
                                AddLife(player.Y, player.X + 1, matrix);
                                matrix[player.Y, player.X + 1] = 0;
                            }
                            else if (matrix[player.Y, player.X + 1]== 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharMatrixAtPosition(player.Y, player.X, ' ');
                            player.X++;
                        }
                       
                    }
                }

                Visualization.PrintCharMatrixAtPosition(player.Y, player.X, player.PlayerSymbol, player.Color);
                Visualization.PrintStringAtPosition(65, 2, "SCORES: " + Score.ScoreCount, ConsoleColor.White);
                Visualization.PrintStringAtPosition(65, 4, "LIVES: " + new string('\u2665', Life.LifeCount), ConsoleColor.Red);
                Visualization.PrintStringAtPosition(65, 10, "Captain of your ship needs help", ConsoleColor.Red);
                Visualization.PrintStringAtPosition(65, 12, "to collect some supplies for the", ConsoleColor.Red);
                Visualization.PrintStringAtPosition(78, 14, "battle.", ConsoleColor.Red);
                Visualization.PrintStringAtPosition(65, 34, "e - next level", ConsoleColor.Green);
                Visualization.PrintStringAtPosition(65, 32, '\u2665' + " - lives", ConsoleColor.Red);
                Visualization.PrintStringAtPosition(65, 30, "3-6 - points", ConsoleColor.Blue);

                Visualization.PrintStringAtPosition(60, 20, new string('*', 40), ConsoleColor.White);
                for (int i = 1; i < 20; i++)
                {
                    Visualization.PrintStringAtPosition(60, i, "*", ConsoleColor.White);
                }


                Thread.Sleep(50);
            }
        }

        public static void AddScores(int playerY, int playerX, int [,] matrix)
        {
            for (int bonusScore = 3; bonusScore < 7; bonusScore++)
            {
                if (matrix[playerY, playerX] == bonusScore)
                {
                    Score.ScoreCount+=bonusScore;
                   
                }
            }
          
        }
        public static void AddLife(int playerY, int playerX, int[,] matrix)
        {
           
                if (matrix[playerY, playerX] == 7)
                {
                    Life.LifeCount += 1;
                }
        }

        public static void DrawField(int[,] matrix)
        {
            Random randomWidthGenerator = new Random();
            Random randomValue = new Random();
            Random randomDigit = new Random();
            Random randomLifeChance = new Random();
            int chance = randomLifeChance.Next(1, 100);

            //exit
            matrix[1, 1] = 8;

            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            //draw matrix borders
            for (int brick = 0; brick < height; brick++)
            {
                matrix[brick, 0] = 1;
                matrix[0, brick] = 1;
                matrix[height - 1, brick] = 1;
                matrix[brick, height - 1] = 1;
            }
           

            //draw matrix grid
            for (int row = 5; row < height - 5; row += 5)
            {
                for (int col = 0; col < width; col++)
                {
                    matrix[row, col] = 1;
                }
            }


            //draw doors
            for (int row = 1; row < height - 1; row++)
            {
                int randomHole = randomValue.Next(1, width - 1);
                if (matrix[row, randomHole] == 1)
                {
                    if (matrix[row, randomHole] != 8)
                    {
                        matrix[row, randomHole] = 0;
                    }
                }
            }

            //draw digits
            for (int row = 1; row < height - 1; row++)
            {
                int randomCol = randomWidthGenerator.Next(1, width - 1);
                int random = randomDigit.Next(3, 9);
                if (matrix[row, randomCol] == 0)
                {
                    matrix[row, randomCol] = random;
                }
            }


            //Console.ForegroundColor = ConsoleColor.White;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        Visualization.PrintCharMatrixAtPosition(row, col, '#', ConsoleColor.White);
                    }

                    else if (matrix[row, col] >= 3 && matrix[row, col] <= 6)
                    {
                        Visualization.PrintCharMatrixAtPosition(row, col, (char)(matrix[row, col]+48), ConsoleColor.Blue);
                        
                    }
                    else if (matrix[row, col] == 7 && chance > 20)
                    {
                        Visualization.PrintCharMatrixAtPosition(row, col, '\u2665', ConsoleColor.Red);
                       
                    }
                    else if (matrix[row, col] == 8 )
                    {
                        Visualization.PrintCharMatrixAtPosition(row, col, '\u0065', ConsoleColor.Green);
                      
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}
