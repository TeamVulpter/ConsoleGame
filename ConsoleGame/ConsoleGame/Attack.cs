using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Attack
    {
        double speed = 100.0;
        double acceleration = 0.5;
        int playfieldWidth = 50;
        int livesCount = 10;
        //internal bool isCaptured = false;
        public void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }

        public void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);

        }

        public void PrintStringPlayerOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }

        public static bool IsThereACollision(int playerX, int playerY, int enemyX, int enemyY)
        {
            if (enemyY == playerY && (enemyX == playerX || enemyX == playerX + 1 || enemyX == playerX + 2 ||
                      enemyX + 1 == playerX || enemyX + 2 == playerX || enemyX + 1 == playerX + 1 ||
                      enemyX + 2 == playerX + 2 || enemyX + 1 == playerX + 2 || enemyX + 2 == playerX + 1))
            {
                return true;
            }
            return false;
        }

        public void UpdateAttack()
        {
            PlayerShip spaceship = new PlayerShip(5, Console.WindowHeight - 2, "_/|\\_", ConsoleColor.Yellow);
            Random randomGenerator = new Random();
            List<EnemyInvader> invader = new List<EnemyInvader>();
            Map map = new Map();

            while (true)
            {
                speed += acceleration;
                if (speed > 400)
                {
                    speed = 400;
                }
                bool isHit = false;

                int chance = randomGenerator.Next(0, 100);
                // Falling enemies color and shape
                if (chance < 2)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Green);
                    invader.Add(newInvader);

                }
                else if (chance < 5)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Red);

                    invader.Add(newInvader);
                }
                else if (chance < 8)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Blue);

                    invader.Add(newInvader);
                }
                else if (chance < 10)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Cyan);
                    invader.Add(newInvader);
                }
                else if (chance < 13)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Magenta);
                    invader.Add(newInvader);
                }
                else if (chance < 15)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Magenta);
                    invader.Add(newInvader);
                }
                else if (chance < 18)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.DarkBlue);
                    invader.Add(newInvader);
                }
                else if (chance < 20)
                {
                    EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.White);
                    invader.Add(newInvader);
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
                        if (spaceship.X - 1 >= 0)
                        {
                            spaceship.X = spaceship.X - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (spaceship.X + 1 < playfieldWidth)
                        {
                            spaceship.X = spaceship.X + 1;
                        }
                    }
                }
                List<EnemyInvader> newList = new List<EnemyInvader>();
                for (int i = 0; i < invader.Count; i++)
                {

                    EnemyInvader oldInvader = invader[i];
                    EnemyInvader newInvader = new EnemyInvader();
                    newInvader.X = oldInvader.X;
                    newInvader.Y = oldInvader.Y + 1;
                    newInvader.C = oldInvader.C;
                    newInvader.Color = oldInvader.Color;

                    if (IsThereACollision(spaceship.X, spaceship.Y, newInvader.X, newInvader.Y))
                    {
                        livesCount--;
                        PrintOnPosition(spaceship.X, spaceship.Y, 'X', ConsoleColor.Red);
                        if (livesCount <= 0)
                        {

                            PrintStringOnPosition(8, 10, "GAME OVER", ConsoleColor.Red);
                            PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                            //Console.Clear();
                            //isCaptured=true;
                            // map.CreateTable();
                            // map.UpdateMap();
                            Console.ReadLine();
                            Environment.Exit(0);
                            //return;
                        }
                    }
                    if (newInvader.Y < Console.WindowHeight)
                    {
                        newList.Add(newInvader);
                    }
                }
                invader = newList;
                Console.Clear();
                PrintStringPlayerOnPosition(spaceship.X, spaceship.Y, spaceship.C, spaceship.Color);
                foreach (EnemyInvader unit in invader)
                {
                    PrintStringOnPosition(unit.X, unit.Y, unit.C, unit.Color);
                }
                if (isHit)
                {
                    PrintOnPosition(spaceship.X, spaceship.Y, 'X', ConsoleColor.Red);// It appears when it's game over

                }

                PrintStringOnPosition(10, 1, "LIVES: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(20, 1, "SCORES: ", ConsoleColor.White);
                PrintStringOnPosition(30, 1, "TIME: ", ConsoleColor.White);
                Thread.Sleep(150);
            }
        }
    }
}
