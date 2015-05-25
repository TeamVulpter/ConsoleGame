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
            ////Since the play field width is created in the Attack class I do not understand why i causes an exception here.Uncomment and try!
            ////for (int i =35 ; i < 60; i++)
            ////{
            ////    Visualization.PrintStringAtPosition(i,5,"_",ConsoleColor.White);
            ////}
            ////Writing some welcome text. Remove it if you don't like it :)
            //Visualization.PrintStringAtPosition(25, 10, "Welcome to Space Invaders", ConsoleColor.DarkCyan);
            //Visualization.PrintStringAtPosition(29,12, "Press \"V\" to start",ConsoleColor.DarkCyan);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../GameMusic.wav");
            player.Play();

            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 100;

            keyPressed = Console.ReadKey();
            Attack attack = new Attack();
            
            while (true)
            {

                if (keyPressed.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    Map.UpdateMap();
                }

                if (keyPressed.Key == ConsoleKey.V)
                {
                    attack.UpdateAttack();
                }
                
            }
           
        }
    }
}
