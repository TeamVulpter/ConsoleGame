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
        internal bool isCaptured = false;
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

        public void UpdateAttack()
        {

            PlayerShip spaceship = new PlayerShip();
            spaceship.x = 5;
            spaceship.y = Console.WindowHeight - 2;
            spaceship.c = "_/|\\_";
            spaceship.color = ConsoleColor.Yellow;
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
                bool hitted = false;

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
                List<EnemyInvader> newList = new List<EnemyInvader>();
                for (int i = 0; i < invader.Count; i++)
                {

                    EnemyInvader oldInvader = invader[i];
                    EnemyInvader newInvader = new EnemyInvader();
                    newInvader.X = oldInvader.X;
                    newInvader.Y = oldInvader.Y + 1;
                    newInvader.C = oldInvader.C;
                    newInvader.Color = oldInvader.Color;

                    if (newInvader.Y == spaceship.y && (newInvader.X == spaceship.x || newInvader.X == spaceship.x + 1 || newInvader.X == spaceship.x + 2 ||
                       newInvader.X + 1 == spaceship.x || newInvader.X + 2 == spaceship.x || newInvader.X + 1 == spaceship.x + 1 ||
                       newInvader.X + 2 == spaceship.x + 2 || newInvader.X + 1 == spaceship.x + 2 || newInvader.X + 2 == spaceship.x + 1))
                    {
                        livesCount--;
                        PrintOnPosition(spaceship.x, spaceship.y, 'X', ConsoleColor.Red);
                        if (livesCount <= 0)
                        {

                            PrintStringOnPosition(8, 10, "GAME OVER", ConsoleColor.Red);
                            PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                            Console.Clear();
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
                PrintStringPlayerOnPosition(spaceship.x, spaceship.y, spaceship.c, spaceship.color);
                foreach (EnemyInvader unit in invader)
                {
                    PrintStringOnPosition(unit.X, unit.Y, unit.C, unit.Color);
                }
                if (hitted)
                {
                    PrintOnPosition(spaceship.x, spaceship.y, 'X', ConsoleColor.Red);// It appears when it's game over

                }

                PrintStringOnPosition(10, 1, "LIVES: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(20, 1, "SCORES: ", ConsoleColor.White);
                PrintStringOnPosition(30, 1, "TIME: ", ConsoleColor.White);
                Thread.Sleep(150);
            }
        }
    }
}
