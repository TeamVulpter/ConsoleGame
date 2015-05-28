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
        private static double speed = 400.0;
        private static double acceleration = 0.5;
        private const int playfieldWidth = 50;
        private static List<Bullet> shots = new List<Bullet>();
        private static List<EnemyInvader> invader = new List<EnemyInvader>();
        private static PlayerShip spaceship = new PlayerShip(5, Console.WindowHeight - 2, "_/|\\_", ConsoleColor.Yellow);
        private static int steps = 0;
        private static int enemiesPause = 3;
        private static Map map = new Map();
        private static Random randomGenerator = new Random();

        public static bool CheckCollision(string invader, string itemOrCharacter, int itemOrCharacterX, int itemOrCharacterY, int invaderX, int invaderY)
        {
            bool result = false;
            for (int i = 0; i < invader.Length; i++)
            {
                for (int j = 0; j < itemOrCharacter.Length; j++)
                {
                    if (itemOrCharacterY == invaderY && itemOrCharacterX + j == invaderX + i)
                    {
                        
                        result = true;
                    }
                }
            }
            return result;
        }

        public static void UpdateAttack()
        {
           
            while (true)
            {
                speed += acceleration;
                if (speed > 400)
                {
                    speed = 400;
                }

                MovePlayerShip();

                if (steps % enemiesPause == 0)
                {
                    GenerateEnemies(randomGenerator);
                    MoveEnemies();
                }
                steps++;
                TakeLivesTillPlayerIsDead();
                CheckEnemyAndShotsCollision();
                Shooting.UpdateShots(shots);
                Console.Clear();
                Visualization.PrintStringAtPosition(spaceship.X, spaceship.Y, spaceship.PlayerString, spaceship.Color);

                foreach (var shot in shots)
                {
                    if (shot.Y > 0 && shot.Y < Console.WindowHeight - 3)
                    {
                        Visualization.PrintStringAtPosition(shot.X, shot.Y, shot.BulletSymbol, shot.Color);
                    }
                }
              

                foreach (EnemyInvader unit in invader)
                {
                    Visualization.PrintStringAtPosition(unit.X, unit.Y, unit.EnemyInvaderString, unit.Color);
                }
                Visualization.PrintStringAtPosition(70, 2, "LIVES: " + new string('\u2665', Life.LifeCount), ConsoleColor.Red);
                Visualization.PrintStringAtPosition(70, 4, "SCORES: " + Score.ScoreCount, ConsoleColor.White);
                Visualization.PrintStringAtPosition(60, 20, new string('*', 40), ConsoleColor.White);
                for (int i = 1; i < 20; i++)
                {
                    Visualization.PrintStringAtPosition(60, i, "*", ConsoleColor.White);
                }

                if (Score.ScoreCount >= 200)
                {
                    Console.Clear();
                    Visualization.PrintStringAtPosition(40, 10, "GAME OVER! YOU WIN!", ConsoleColor.Green);
                    Scoreboard.GenerateScoreboard();
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Environment.Exit(0);
                  
                }
                Thread.Sleep((int)(600 - speed));
            }
        }

        private static void CheckEnemyAndShotsCollision()
        {
            List<int> enemiesToRemove = new List<int>();
            List<int> shotsToRemove = new List<int>();

            for (int shot = 0; shot < shots.Count; shot++)
            {
                for (int enemy = 0; enemy < invader.Count; enemy++)
                {
                    if (CheckCollision(invader[enemy].EnemyInvaderString, shots[shot].BulletSymbol, shots[shot].X, shots[shot].Y, invader[enemy].X, invader[enemy].Y))
                    {
                        Score.ScoreCount++;
                        enemiesToRemove.Add(enemy);
                        shotsToRemove.Add(shot);
                    }
                }
            }
            List<EnemyInvader> newEnemies = new List<EnemyInvader>();
            List<Bullet> newShots = new List<Bullet>();

            for (int i = 0; i < invader.Count; i++)
            {
                if (!enemiesToRemove.Contains(i))
                {
                    newEnemies.Add(invader[i]);
                }
            }

            for (int i = 0; i < shots.Count; i++)
            {
                if (!shotsToRemove.Contains(i))
                {
                    newShots.Add(shots[i]);
                }
            }

            invader = newEnemies;
            shots = newShots;
        }

        private static void TakeLivesTillPlayerIsDead()
        {
            for (int enemy = 0; enemy < invader.Count; enemy++)
            {
                if (CheckCollision(invader[enemy].EnemyInvaderString, spaceship.PlayerString, spaceship.X, spaceship.Y, invader[enemy].X, invader[enemy].Y) || invader[enemy].Y == Console.WindowHeight - 4)
                {
                    Life.LifeCount--;

                    if (invader.Count > 1)
                    {
                        invader.Remove(invader[enemy]);
                    }

                    Visualization.PrintOnPosition(spaceship.X, spaceship.Y, 'X', ConsoleColor.Red);
                    if (Life.LifeCount <= 0)
                    {
                        Console.Clear();
                        Visualization.PrintStringAtPosition(40, 10, "GAME OVER! YOU LOSE!", ConsoleColor.Red);
                        Scoreboard.GenerateScoreboard();
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Black;
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void MoveEnemies()
        {
            List<EnemyInvader> newList = new List<EnemyInvader>();
            for (int i = 0; i < invader.Count; i++)
            {

                EnemyInvader oldInvader = invader[i];
                EnemyInvader newInvader = new EnemyInvader();
                newInvader.X = oldInvader.X;
                newInvader.Y = oldInvader.Y + 1;
                newInvader.EnemyInvaderString = oldInvader.EnemyInvaderString;
                newInvader.Color = oldInvader.Color;

                if (newInvader.Y < Console.WindowHeight - 1)
                {
                    newList.Add(newInvader);
                }
            }
            invader = newList;
        }

        private static void MovePlayerShip()
        {
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

                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    Shooting.Shoot(spaceship, shots);
                }
            }
        }

        private static void GenerateEnemies(Random randomGenerator)
        {
            int chance = randomGenerator.Next(0, 100);

            if (chance < 5)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Green);
                invader.Add(newInvader);
            }
            else if (chance < 7)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Red);

                invader.Add(newInvader);
            }
            else if (chance < 10)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "//|\\\\", ConsoleColor.Green);

                invader.Add(newInvader);
            }
            else if (chance < 12)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Cyan);
                invader.Add(newInvader);
            }
            else if (chance < 15)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "//|\\\\", ConsoleColor.Magenta);
                invader.Add(newInvader);
            }
            else if (chance < 17)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.Magenta);
                invader.Add(newInvader);

            }
            else if (chance < 20)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "//|\\\\", ConsoleColor.Cyan);
                invader.Add(newInvader);
            }
            else if (chance < 20)
            {
                EnemyInvader newInvader = new EnemyInvader(randomGenerator.Next(0, playfieldWidth), 0, "\\\\|//", ConsoleColor.White);
                invader.Add(newInvader);
            }
        }
    }
}
