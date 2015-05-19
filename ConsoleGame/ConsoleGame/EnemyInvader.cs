using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class EnemyInvader
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string C { get; set; }
        public ConsoleColor Color { get; set; }

        public EnemyInvader()
        {

        }

        public EnemyInvader(int x, int y, string c, ConsoleColor color)
            :this()
        {
            this.X = x;
            this.Y = y;
            this.C = c;
            this.Color = color;
        }

        

        
    }
}
