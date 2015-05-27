using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Player
    {
        public Player(int y, int x, char playerSymbol, ConsoleColor consoleColor)
        {
            this.Y = y;
            this.X = x;
            this.PlayerSymbol = playerSymbol;
            this.Color = consoleColor;
        }

        public int Y { get; set; }
        public int X { get; set; }
        public char PlayerSymbol { get; private set; }
        public ConsoleColor Color { get; private set; }
    }
}
