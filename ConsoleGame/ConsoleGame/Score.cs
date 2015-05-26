using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Score
    {
        public static int scoreCount = 0;
        
        public static int ScoreCount
        {
            get { return scoreCount; }
            set { scoreCount = value; }

        }
    }
}
