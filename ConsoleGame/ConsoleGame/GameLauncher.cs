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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
            System.Media.SoundPlayer musicPlayer = new System.Media.SoundPlayer("../../GameMusic.wav");
            musicPlayer.PlayLooping();
           
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Enter)
                    {
                        musicPlayer.Stop();
                        Console.Clear();
                        Map.UpdateMap();
                    }
                }
            }
        }
    }
}
