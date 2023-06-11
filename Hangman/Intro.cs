using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class GameInstructions
    {
        public static void Intro()
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
            if (wantTutorial == "y")
            {
                ShowTutorial();
            }
            if (wantTutorial == "n")
            {
                Console.WriteLine("");
                Console.WriteLine("Cool, then let's just get started. Press any key to continue");
                Console.ReadLine();
            }
            Console.Clear();
        }
        public static void ShowTutorial()
        {

            Console.Clear();
            string[,] gallowsGrid = CommonFunctions.BaseGallow();

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

            CommonFunctions.DisplayGallow(gallowsGrid);

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
    }
}
