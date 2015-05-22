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
        public void UpdateMap()
        {
            int[,] array = new int[40, 40];

            Player player = new Player(40 - 2,  40/2, '@', ConsoleColor.Red);

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
            int randomWidth = randomWidthGenerator.Next(0, 20);
            int randomHeight = randomHeightGenerator.Next(0, 20);

            int height = array.GetLength(0);
            int width = array.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                array[i, 0] = 1;
                array[0, i] = 1;
                array[height - 1, i] = 1;
                array[i, height - 1] = 1;
            }

            for (int i = 0; i < height - 6; i++)
            {
                //array[i + 3, 3] = 1;
                array[3, i + 3] = 1;
                array[6, i + 3] = 1;
                array[9, i + 3] = 1;
                array[12, i + 3] = 1;
                array[15, i + 3] = 1;
                array[18, i + 3] = 1;
                array[21, i + 3] = 1;
                array[24, i + 3] = 1;
                array[27, i + 3] = 1;
                array[30, i + 3] = 1;
                array[33, i + 3] = 1;
                array[height - 4, i + 3] = 1;
             
            }


            for (int i = 0; i < height - 6; i++)
            {
                array[i + 3, height-1] = 1;
                array[height / 2 + 1, i + 3] = 1;
            }

            array[3, 19] = 0;
            array[6, 19] = 0;
           
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (array[row, col]!=1)
                    {
                        array[randomHeight, randomWidth]=3;
                    }
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
                   
                    else if (array[i, j] == 3)
                    {
                        Console.Write("3");
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
