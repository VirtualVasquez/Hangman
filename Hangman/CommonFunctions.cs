using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class CommonFunctions
    {
        public static string[,] BaseGallow()
        {
            string[,] newGallow = new string[7, 7];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0)
                    {
                        if (j < 2)
                        {
                            newGallow[i, j] = " ";
                        }
                        else
                        {
                            newGallow[i, j] = "_";
                        }
                    }
                    else if (i == 6)
                    {
                        if (j == 6)
                        {
                            newGallow[i, j] = "|";
                        }
                        else
                        {
                            newGallow[i, j] = "_";
                        }
                    }
                    else
                    {
                        if (j != 6)
                        {
                            newGallow[i, j] = " ";
                        }
                        else
                        {
                            newGallow[i, j] = "|";
                        }
                    }

                }
            }

            return newGallow;
        }
        public static void DisplayGallow(string[,] gallow)
        {
            for (int a = 0; a < gallow.GetLength(0); a++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(" ");
                }
                for (int b = 0; b < 7; b++)
                {
                    Console.Write("{0}", gallow[a, b]);
                }
                Console.WriteLine("");
            }
        }
    }
}
