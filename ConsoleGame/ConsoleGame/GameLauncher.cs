using System;
using System.Collections.Generic;
using System.IO;
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
            //Visualization.PrintStringAtPosition(29, 12, "Press \"V\" to start", ConsoleColor.DarkCyan);
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 100;
            StreamReader reader = new StreamReader(@"../../intro.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
            System.Media.SoundPlayer musicPlayer = new System.Media.SoundPlayer("../../GameMusic.wav");
            musicPlayer.PlayLooping();
            //Console.WriteLine(Map.score);
           
           

            keyPressed = Console.ReadKey();

            while (true)
            {

                if (keyPressed.Key == ConsoleKey.V)
                {
                    musicPlayer.Stop();
                    Console.Clear();
                    Map.UpdateMap();
                }

                //if (keyPressed.Key == ConsoleKey.V)
                //{
                //    Attack.UpdateAttack();
                //}
                
            }
           
        }
    }
}
