using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Visualization
    {
        public static void PrintOnPosition(int x, int y, char charSymbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(charSymbol);
        }

        public  static void PrintStringAtPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        public static void PrintCharMatrixAtPosition(int y, int x, char playerSymbol, ConsoleColor color = ConsoleColor.DarkRed)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(playerSymbol);
        }
    }
}
