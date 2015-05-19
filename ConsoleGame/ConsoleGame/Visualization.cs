using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Visualization
    {
        public void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }

        public void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);

        }

        public void PrintStringPlayerOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }


        public static void DrawShots(List<List<int>> shots, char shotSymbol)
        {
            foreach (List<int> shot in shots)
            {
                ConsoleColor shotColor = ConsoleColor.Blue;
                DrawSymbolAtCoordinates(shot, shotSymbol, shotColor);
            }
        }
        private static void DrawSymbolAtCoordinates(List<int> coordinates, char symbol, ConsoleColor color)
        {
            Console.SetCursorPosition(coordinates[0], coordinates[1]);
            Console.ForegroundColor = color;
            Console.WriteLine(symbol);
        }

        //public static void DrawSymbolAtCoordinates(int shotX, int shotY, char symbol, ConsoleColor color = ConsoleColor.Gray)
        //{
        //    Console.SetCursorPosition(shotX, shotY);
        //    Console.ForegroundColor = color;
        //    Console.WriteLine(symbol);
        //}
    }
}
