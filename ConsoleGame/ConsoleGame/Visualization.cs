using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Visualization
    {
        public static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }

        public  static void PrintStringAtPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);

        }

        public static void PrintCharAtPosition(int x, int y, char playerSymbol, ConsoleColor color = ConsoleColor.DarkRed)
        {
            Console.SetCursorPosition(y, x);
            Console.ForegroundColor = color;
            Console.Write(playerSymbol);
        }

        

        public static void DrawSymbolAtCoordinates(int shotX, int shotY, string symbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(shotX, shotY);
            Console.ForegroundColor = color;
            Console.WriteLine(symbol);
        }
    }
}
