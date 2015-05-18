using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Map
    {
        private string[,] matrix1 = new string[24, 39]; 
        private int timer = 60;
        private int timethingy = 0;
        private int endcycle = 0;
        private ConsoleKeyInfo keyprime;
        private int z;
        private int p;

        public void CreateTable()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    matrix1[i, j] = ".";
                }
            }
            z = 1;
            p = 1;
            matrix1[z, p] = "@";
            //###################################################################################
            for (int i = 0; i < 24; i++)
            {
                matrix1[i, 0] = "O";
                matrix1[i, 38] = "O";
            }
            for (int j = 0; j < 39; j++)
            {
                matrix1[0, j] = "O";
                matrix1[23, j] = "O";
            }
            PrintTable(matrix1);
        }

        public void PrintTable(string[,] matrix)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void UpdateMap()
        {
            //ConsoleKeyInfo keyprime;
            keyprime = Console.ReadKey();
            //###########################
            if (keyprime.Key == ConsoleKey.DownArrow || keyprime.Key == ConsoleKey.S)
            {
                if (z < 24)
                {
                    if (matrix1[z + 1, p] == ".")
                    {
                        matrix1[z + 1, p] = matrix1[z, p];
                        matrix1[z, p] = ".";
                        z++;
                        Console.Clear();
                        PrintTable(matrix1);
                    }
                }
            }
            if (keyprime.Key == ConsoleKey.UpArrow || keyprime.Key == ConsoleKey.W)
            {
                if (z > 0)
                {
                    if (matrix1[z - 1, p] == ".")
                    {
                        matrix1[z - 1, p] = matrix1[z, p];
                        matrix1[z, p] = ".";
                        z--;
                        Console.Clear();
                        PrintTable(matrix1);
                    }
                }
            }
            if (keyprime.Key == ConsoleKey.RightArrow || keyprime.Key == ConsoleKey.D)
            {
                if (p < 37)
                {
                    if (matrix1[z, p + 1] == ".")
                    {
                        matrix1[z, p + 1] = matrix1[z, p];
                        matrix1[z, p] = ".";
                        p++;
                        Console.Clear();
                        PrintTable(matrix1);
                    }
                }
            }
            if (keyprime.Key == ConsoleKey.LeftArrow || keyprime.Key == ConsoleKey.A)
            {
                if (p > 0)
                {
                    if (matrix1[z, p - 1] == ".")
                    {
                        matrix1[z, p - 1] = matrix1[z, p];
                        matrix1[z, p] = ".";
                        p--;
                        Console.Clear();
                        PrintTable(matrix1);
                    }
                }
            }
            if (keyprime.Key == ConsoleKey.Escape) endcycle++;
            //########################
        }
    }
}
