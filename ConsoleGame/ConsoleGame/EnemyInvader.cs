using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class EnemyInvader
    {
        public EnemyInvader()
        {

        }

        public EnemyInvader(int x, int y, string enemyInvaderString, ConsoleColor color)
            :this()
        {
            this.X = x;
            this.Y = y;
            this.EnemyInvaderString = enemyInvaderString;
            this.Color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string EnemyInvaderString { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
