using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Attack
    {
        double speed = 400.0;
        double acceleration = 0.5;
        int playfieldWidth = 50;
        int livesCount = 10;
        int scoresCount = 0;
        static int bulletPosition = 0;
        Visualization print = new Visualization();
        static List<Bullet> shots = new List<Bullet>();
        
        private static void Shoot()
        {
            Bullet bullet = new Bullet(bulletPosition, Console.WindowHeight - 3, "|", ConsoleColor.Blue);
            shots.Add(bullet);
            foreach (var shot in shots)
            {
                shot.Y = Console.WindowHeight - 3;
                shot.X = bulletPosition;
            }

        }

        private static void UpdateShots()
        {
            for (int i = 0; i < shots.Count; i++)
            {
                shots[i].Y = shots[i].Y - 1;
            }

            int index = -1;

            for (int i = 0; i < shots.Count; i++)
            {
                if (shots[i].Y <= 1)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                shots.RemoveAt(index);
            }
        }

        public static bool CheckCollision(string invader, string spaceship, int spaceshipX, int spaceshipY, int invaderX, int invaderY)
        {
            bool result=false;
            for (int i = 0; i < invader.Length; i++)
            {
                for (int j = 0; j < spaceship.Length; j++)
                {
                    if (spaceshipY==invaderY && spaceshipX+j==invaderX+i)
                    {
                        result = true;
                    }
                }
                
            }   
            return result;
        }

        public void UpdateAttack()
        {
            PlayerShip spaceship = new PlayerShip(5, Console.WindowHeight - 2, "_/|\\_", ConsoleColor.Yellow);
            Bullet bullet = new Bullet(bulletPosition, Console.WindowHeight - 3, "|", ConsoleColor.Blue);
            List<Bullet> bullets = new List<Bullet>();
            Random randomGenerator = new Random();
            List<EnemyInvader> invader = new List<EnemyInvader>();
            Map map = new Map();

            while (true)
            {
                speed += acceleration;
                if (speed > 200)
                {
                    speed = 200;
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
                            //speed = 550;
                        }

                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (spaceship.X + 1 < playfieldWidth)
                        {
                            spaceship.X = spaceship.X + 1;
                            //speed=550;
                        }

                    }

                    if (pressedKey.Key == ConsoleKey.Spacebar)
                    {
                        Shoot();
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

                    if(CheckCollision(newInvader.C, spaceship.C, spaceship.X, spaceship.Y, newInvader.X, newInvader.Y))
                    {
                        livesCount--;
                        print.PrintOnPosition(spaceship.X, spaceship.Y, 'X', ConsoleColor.Red);
                        if (livesCount <= 0)
                        {

                            print.PrintStringOnPosition(8, 10, "GAME OVER", ConsoleColor.Red);
                            print.PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
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
                
                foreach (Bullet item in shots)
                {
                    for (int j = 0; j < invader.Count; j++)
                    {
                        if (CheckCollision(invader[j].C, item.C, item.X, item.Y, invader[j].X, invader[j].Y))
                        {
                            scoresCount++;
                            invader.RemoveAt(j);
                        }
                    }
                }
                UpdateShots();
                Console.Clear();

                print.PrintStringPlayerOnPosition(spaceship.X, spaceship.Y, spaceship.C, spaceship.Color);
                bulletPosition = spaceship.X + 2;
                foreach (var shot in shots)
                {
                    if (shot.Y>0 && shot.Y < Console.WindowHeight - 3)
                    {
                        Visualization.DrawSymbolAtCoordinates(shot.X, shot.Y, shot.C, shot.Color);
                    }
                    
                }
                

                foreach (EnemyInvader unit in invader)
                {
                    print.PrintStringOnPosition(unit.X, unit.Y, unit.C, unit.Color);
                }
                if (isHit)
                {
                    print.PrintOnPosition(spaceship.X, spaceship.Y, 'X', ConsoleColor.Red);// It appears when it's game over

                }

              //This is how I think is easier to draw some kind of a playfield. It is absolutely basic. I am open for Ideas

                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    print.PrintStringOnPosition(54, i, "*");
                }
                for (int i = 55; i < Console.WindowWidth; i++)
                {
                    print.PrintStringOnPosition(i,15,"*");
                }
               
                print.PrintStringOnPosition(70, 2, "LIVES: " + livesCount, ConsoleColor.White);
                print.PrintStringOnPosition(70, 4, "SCORES: " +scoresCount, ConsoleColor.White);
                print.PrintStringOnPosition(70, 6, "TIMER:", ConsoleColor.White); //I have to learn how to implement the Timer class which is built in in .net.

                //print.PrintStringOnPosition();
                Thread.Sleep(150);
                //Thread.Sleep((int)(600 - speed));
            }
        }
    }
}
