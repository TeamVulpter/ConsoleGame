using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Life
    {
        private static int lifeCount = 2;
        public static int LifeCount
        {
            get { return lifeCount; }
            set { lifeCount = value; }

        }
    }
}
