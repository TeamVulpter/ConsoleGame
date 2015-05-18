using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulpterDungeon
{
    class VulpterDungeon
    {
        private static void PrintTable(string[,] matrix)
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

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyprime;
            string[,] matrix1 = new string[24, 39];
            int timer = 60;
            int timethingy = 0;
            int endcycle = 0;
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    matrix1[i, j] = ".";
                }
            }
            int z = 1;
            int p = 1;
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


            //##################
            //###################################################################################
            PrintTable(matrix1);
            do
            {
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
            } while (endcycle != 1);

        }
    }
}
