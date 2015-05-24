using System;
using System.Timers;

namespace TimerExample
{
    class GameTmer
    {
        static Timer timer = new Timer(1000);
        static int i = 10;

        public static void Countdown()
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Console.Read();
        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            i--;
            Console.Clear();
            Console.WriteLine("Time Remaining:  " + i.ToString());

            if (i == 0)
            {
                Console.WriteLine("G A M E  O V E R");
                timer.Close();
                timer.Dispose();
            }
            GC.Collect();
        }
    }
}
