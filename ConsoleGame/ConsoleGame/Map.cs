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
        public static void UpdateMap()
        {
            int[,] array = new int[40, 40];

            Player player = new Player(40 - 2, 40 / 2, '@', ConsoleColor.Red);

            DrawField(array);

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        if (array[player.X - 1, player.Y] != 1)
                        {
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.X--;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (array[player.X + 1, player.Y] != 1)
                        {
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.X++;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (array[player.X, player.Y - 1] != 1)
                        {
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.Y--;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (array[player.X, player.Y + 1] != 1)
                        {
                            Visualization.PrintCharAtPosition(player.X, player.Y, ' ');
                            player.Y++;
                        }
                    }
                }

                Visualization.PrintCharAtPosition(player.X, player.Y, player.PlayerSymbol, player.Color);

                Thread.Sleep(50);
            }
        }

        public static void DrawField(int[,] array)
        {
            Random randomWidthGenerator = new Random();
            Random randomHeightGenerator = new Random();
            Random randomValue = new Random();
            Random randomDigit = new Random();
            Random randomLifeChance = new Random();
            int scores = 0;
            int chance = randomLifeChance.Next(1, 100);

            int height = array.GetLength(0);
            int width = array.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                array[i, 0] = 1;
                array[0, i] = 1;
                array[height - 1, i] = 1;
                array[i, height - 1] = 1;
            }

            //draw matrix grid
            for (int row = 5; row < width - 5; row += 5)
            {
                for (int i = 0; i < height; i++)
                {
                    array[row, i] = 1;
                }
            }


            //draw doors
            for (int i = 1; i < height - 1; i++)
            {
                int randomHole = randomValue.Next(1, width - 1);
                if (array[i, randomHole] == 1)
                {
                    array[i, randomHole] = 0;
                }
            }

            //draw digits

            for (int i = 1; i < height - 1; i++)
            {
                int randomCol = randomWidthGenerator.Next(1, width - 1);
                int random = randomDigit.Next(3, 10);
                if (array[i, randomCol] == 0)
                {

                    array[i, randomCol] = random;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (array[i, j] == 1)
                    {
                        Console.Write("#");
                    }

                    else if (array[i, j] >= 3 && array[i, j] <= 8)
                    {
                        Console.Write(array[i, j]);
                        
                    }
                    else if (array[i, j] == 9 && chance < 30)
                    {
                        Console.Write('\u2665');
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
