using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VulpterInvaders
{
    class VulpterInvaders
    {
        
        static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }

        static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);

        }

        static void PrintStringPlayerOnPosition(int x, int y, string[,] c, ConsoleColor color = ConsoleColor.Gray)
        //static void PrintStringPlayerOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            //Console.WriteLine(c);
            for (int row = 0; row < c.GetLength(0); row++)
            {
                for (int col = 0; col < c.GetLength(1); col++)
                {
                    Console.Write(c[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            double speed = 100.0;
            double acceleration = 0.5;
            int playfieldWidth = 5;
            int livesCount = 5;
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 100;
            Player spaceship = new Player();
            spaceship.x = 5;
            spaceship.y = Console.WindowHeight - 2;
            //spaceship.c = "_/|\\_";
            spaceship.c = new string[3, 3]{
                    { "*"  ,  "*",  "*"},
                    { "*"   , "*",  "*" },
                    { "*" ,  "*",   "*"}
                };
            spaceship.color = ConsoleColor.Yellow;
            Random randomGenerator = new Random();
            List<Enemy> rocks = new List<Enemy>();
            while (true)
            {
                speed += acceleration;
                if (speed > 400)
                {
                    speed = 400;
                }
                bool hitted = false;

                int chance = randomGenerator.Next(0, 100);
                // Falling rocks color and shape
                if (chance < 2)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Green;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '^';
                    rocks.Add(newRock);
                }
                else if (chance < 5)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Red;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '@';
                    rocks.Add(newRock);
                }
                else if (chance < 8)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Blue;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '*';
                    rocks.Add(newRock);
                }
                else if (chance < 10)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Cyan;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '$';
                    rocks.Add(newRock);
                }
                else if (chance < 13)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Magenta;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '#';
                    rocks.Add(newRock);
                }
                else if (chance < 15)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.Magenta;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '!';
                    rocks.Add(newRock);
                }
                else if (chance < 18)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.DarkBlue;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = '.';
                    rocks.Add(newRock);
                }
                else if (chance < 20)
                {
                    Enemy newRock = new Enemy();
                    newRock.color = ConsoleColor.White;
                    newRock.x = randomGenerator.Next(0, playfieldWidth);
                    newRock.y = 0;
                    newRock.c = ';';
                    rocks.Add(newRock);
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (spaceship.x - 1 >= 0)
                        {
                            spaceship.x = spaceship.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (spaceship.x + 1 < playfieldWidth)
                        {
                            spaceship.x = spaceship.x + 1;
                        }
                    }
                }
                List<Enemy> newList = new List<Enemy>();
                for (int i = 0; i < rocks.Count; i++)
                {

                    Enemy oldRock = rocks[i];
                    Enemy newRock = new Enemy();
                    newRock.x = oldRock.x;
                    newRock.y = oldRock.y + 1;
                    newRock.c = oldRock.c;
                    newRock.color = oldRock.color;

                    if (newRock.y == spaceship.y && newRock.x == spaceship.x || newRock.x == spaceship.x + 1 && newRock.y == spaceship.y || newRock.x == spaceship.x + 2 && newRock.y == spaceship.y)
                    {
                        livesCount--;
                        PrintOnPosition(spaceship.x, spaceship.y, 'X', ConsoleColor.Red);
                        if (livesCount <= 0)
                        {
                            PrintStringOnPosition(8, 10, "GAME OVER", ConsoleColor.Red);
                            PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                            Console.ReadLine();
                            Environment.Exit(0);
                            //return;
                        }
                    }
                    if (newRock.y < Console.WindowHeight)
                    {
                        newList.Add(newRock);
                    }
                }
                rocks = newList;
                Console.Clear();
                PrintStringPlayerOnPosition(spaceship.x, spaceship.y, spaceship.c, spaceship.color);
                foreach (Enemy rock in rocks)
                {
                    PrintOnPosition(rock.x, rock.y, rock.c, rock.color);
                }
                if (hitted)
                {
                    PrintOnPosition(spaceship.x, spaceship.y, 'X', ConsoleColor.Red);// It appears when it's game over
                }
                //else
                //{
                //    PrintOnPosition(spaceship.x, spaceship.y, spaceship.c, spaceship.color);
                //}
                PrintStringOnPosition(8, 4, "Lives" + livesCount, ConsoleColor.White);
                Thread.Sleep(150);
            }
        }
    }
}
