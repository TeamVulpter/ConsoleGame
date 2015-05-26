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
        //public static int score = 0;
        //public static int life = Life.lifeCount;
        public static Player player = new Player(40 - 2, 40 / 2, '@', ConsoleColor.Red);

        //public static int Score
        //{
        //    get { return score; }
        //    set { score = value; }

        //}

        // public static int Life
        //{
        //    get { return life; }
        //    set { life = value; }

        //}

        
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
                        if (matrix[player.X - 1, player.Y] != 1)
                        {
                            if (matrix[player.X - 1, player.Y] > 1 && matrix[player.X - 1, player.Y] != 8)
                            {
                                AddScores(player.X - 1, player.Y, matrix);
                                AddLife(player.X - 1, player.Y, matrix);
                                matrix[player.X - 1, player.Y] = 0;
                            }
                            else if (matrix[player.X - 1, player.Y] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.X--;
                        }
                        
                    }

                    if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (matrix[player.X + 1, player.Y] != 1)
                        {
                            if (matrix[player.X + 1, player.Y] > 1 && matrix[player.X + 1, player.Y] != 8)
                            {
                                AddScores(player.X + 1, player.Y, matrix);
                                AddLife(player.X + 1, player.Y, matrix);
                                matrix[player.X + 1, player.Y] = 0;
                            }
                            else if (matrix[player.X + 1, player.Y] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.X++;
                        }
                      
                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (matrix[player.X, player.Y - 1] != 1)
                        {
                            if (matrix[player.X, player.Y - 1] > 1 && matrix[player.X, player.Y - 1] != 8)
                            {
                                AddScores(player.X, player.Y - 1, matrix);
                                AddLife(player.X, player.Y - 1, matrix);
                                matrix[player.X, player.Y - 1] = 0;
                            }
                            else if (matrix[player.X, player.Y - 1] == 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.Y--;
                        }

                      
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (matrix[player.X, player.Y + 1] != 1)
                        {
                            if (matrix[player.X, player.Y + 1] > 1 && matrix[player.X, player.Y + 1]!=8)
                            {
                                AddScores(player.X, player.Y + 1, matrix);
                                AddLife(player.X, player.Y + 1, matrix);
                                matrix[player.X, player.Y + 1] = 0;
                            }
                            else if (matrix[player.X, player.Y + 1]== 8)
                            {
                                Attack.UpdateAttack();
                            }
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.Y++;
                        }
                       
                    }
                }

                Visualization.PrintCharAtPosition(player.X, player.Y, player.PlayerSymbol, player.Color);
                Visualization.PrintStringAtPosition(70, 4, "SCORES: " + Score.ScoreCount, ConsoleColor.White);
                Visualization.PrintStringAtPosition(70, 2, "LIVES: " + new string('\u2665', Life.LifeCount), ConsoleColor.Red);


                Thread.Sleep(50);
            }
        }

        public static void AddScores(int playerX, int playerY, int [,] matrix)
        {
            for (int i = 3; i < 7; i++)
            {
                if (matrix[playerX, playerY] == i)
                {
                    Score.ScoreCount+=i;
                   
                }
            }
          
        }
        public static void AddLife(int playerX, int playerY, int[,] matrix)
        {
           
                if (matrix[playerX, playerY] == 7)
                {
                    Life.LifeCount += 1;
                    //life += 1;
                }
        }

        public static void DrawField(int[,] matrix)
        {
            Random randomWidthGenerator = new Random();
            Random randomHeightGenerator = new Random();
            Random randomValue = new Random();
            Random randomDigit = new Random();
            Random randomLifeChance = new Random();
            int chance = randomLifeChance.Next(1, 100);

            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                matrix[i, 0] = 1;
                matrix[0, i] = 1;
                matrix[height - 1, i] = 1;
                matrix[i, height - 1] = 1;
            }
            matrix[1, 1] = 8;

            //draw matrix grid
            for (int row = 5; row < width - 5; row += 5)
            {
                for (int i = 0; i < height; i++)
                {
                    matrix[row, i] = 1;
                }
            }


            //draw doors
            for (int i = 1; i < height - 1; i++)
            {
                int randomHole = randomValue.Next(1, width - 1);
                if (matrix[i, randomHole] == 1)
                {
                    if (matrix[i, randomHole] != 8)
                    {
                        matrix[i, randomHole] = 0;
                    }
                }
            }

            //draw digits

            for (int i = 1; i < height - 1; i++)
            {
                int randomCol = randomWidthGenerator.Next(1, width - 1);
                int random = randomDigit.Next(3, 9);
                if (matrix[i, randomCol] == 0)
                {

                    matrix[i, randomCol] = random;
                }
            }


            //Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        Visualization.PrintCharAtPosition(i, j, '#', ConsoleColor.White);
                    }

                    else if (matrix[i, j] >= 3 && matrix[i, j] <= 6)
                    {
                        Visualization.PrintCharAtPosition(i, j, (char)(matrix[i, j]+48), ConsoleColor.Blue);
                        
                    }
                    else if (matrix[i, j] == 7 && chance > 20)
                    {
                        Visualization.PrintCharAtPosition(i, j, '\u2665', ConsoleColor.Red);
                       
                    }
                    else if (matrix[i, j] == 8 )
                    {
                        Visualization.PrintCharAtPosition(i, j, '\u0065', ConsoleColor.Green);
                      
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
