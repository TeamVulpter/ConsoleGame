using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class GameLauncher
    {
        public static ConsoleKeyInfo keyPressed;
        static void Main(string[] args)
        {
            Visualization welcomeText = new Visualization();
            //Since the play field width is created in the Attack class I do not understand why i causes an exception here.Uncomment and try!
            //for (int i =35 ; i < 60; i++)
            //{
            //    welcomeText.PrintStringOnPosition(i,5,"_",ConsoleColor.White);
            //}
            //Writing some welcome text. Remove it if you don't like it :)
            welcomeText.PrintStringOnPosition(25, 10, "Welcome to Space Invaders", ConsoleColor.DarkCyan);
            welcomeText.PrintStringOnPosition(29,12, "Press \"V\" to start",ConsoleColor.DarkCyan);

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
