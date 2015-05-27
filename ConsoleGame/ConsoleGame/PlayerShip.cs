using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class PlayerShip
    {
        public PlayerShip()
        {

        }

        public PlayerShip(int x, int y, string playerString, ConsoleColor color)
            :this()
        {
            this.X = x;
            this.Y = y;
            this.PlayerString = playerString;
            this.Color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string PlayerString { get; private set; }
        public ConsoleColor Color { get; private set; }
    }
}
