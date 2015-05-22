using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Player
    {
        public Player(int p1, int p2, char p3, ConsoleColor consoleColor)
        {
            this.X = p1;
            this.Y = p2;
            this.PlayerSymbol = p3;
            this.Color = consoleColor;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public char PlayerSymbol { get; private set; }
        public ConsoleColor Color { get; private set; }
    }
}
