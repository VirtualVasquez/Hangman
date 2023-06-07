using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
        }
        static void Intro()
        {
            string wantToPlay = "";
            string wantTutorial = "";
            
            while (wantToPlay != "y")
            {
                Console.WriteLine("Do you want to play a game of Hangman? (y or n)");
                wantToPlay = Console.ReadLine();
                if (wantToPlay == "n")
                {
                    Console.WriteLine("Then why are you here?");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Do you want a tutorial? (y or n)");
            wantTutorial = Console.ReadLine();
            if(wantTutorial == "y")
            {
                ShowTutorial();
            }
            if(wantTutorial == "n")
            {
                Console.WriteLine("");
                Console.WriteLine("Cool, then let's just get started. Press any key to continue");
                Console.ReadLine();
            }
            Console.Clear();
        }
        static void ShowTutorial()
        {

            Console.Clear();
            string [,] gallowsGrid = BaseGallow();

            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine("");
            Console.WriteLine("A random word will be selected at the start of the game.");
            Console.WriteLine("For each letter in the word, an underscore character will appear.");
            Console.WriteLine("There will also be a drawing of an empty gallows.");
            Console.WriteLine("");
            Console.WriteLine("Your word: _ _ _ _ _");
            Console.WriteLine("");
            
            DisplayGallow(gallowsGrid);
            
            Console.WriteLine("");
            Console.WriteLine("You will be prompted to guess a letter in the word.");
            Console.WriteLine("You will have a total of eight guesses per word to get it right.");
            Console.WriteLine("Each time you guess wrong, part of the hangman will appear on the gallow, starting with the noose.");
            
            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("When you're ready, press any key to start!");
            Console.ReadLine();
        }
        static string [,] BaseGallow()
        {
            string[,] newGallow = new string[7, 7];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if(i == 0)
                    {
                        if(j < 2)
                        {
                          newGallow[i, j] = " ";
                        }
                        else
                        {
                          newGallow[i, j] = "_";
                        }
                    }
                    else if(i == 6)
                    {
                        if( j == 6)
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
                        if(j != 6)
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
        static void DisplayGallow(string [,] gallow)
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
