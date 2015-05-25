using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Shooting
    {
        public static void Shoot(PlayerShip spaceship, List<Bullet> shots)
        {
            int bulletPosition = spaceship.X + 2;
            shots.Add(new Bullet(bulletPosition, Console.WindowHeight - 3, "|", ConsoleColor.Blue));
        }

        public static void UpdateShots(List<Bullet> shots)
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
    }
}
