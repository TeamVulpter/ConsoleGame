using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class GameLauncher
    {
        public static ConsoleKeyInfo keyPressed;
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 100;

            keyPressed = Console.ReadKey();
            Map map = new Map();
            Attack attack = new Attack();
            if (keyPressed.Key == ConsoleKey.C)
            {
                Console.Clear();
                map.CreateTable();
            }
            
            while (true)
            {

                if (keyPressed.Key == ConsoleKey.C)
                {
                  
                    map.UpdateMap();
                }

                if (keyPressed.Key == ConsoleKey.V)
                {
                    attack.UpdateAttack();
                }
                
            } 
            
        }
    }
}
