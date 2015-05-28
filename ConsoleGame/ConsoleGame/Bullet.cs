using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string BulletSymbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Bullet()
        {

        }

        public Bullet(int x, int y, string bulletSymbol, ConsoleColor color)
            :this()
        {
            this.X = x;
            this.Y = y;
            this.BulletSymbol = bulletSymbol;
            this.Color = color;
        }
    }
}
