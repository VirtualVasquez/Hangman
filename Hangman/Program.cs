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
            //Intro();
            Demo();
            //Game();
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
        static void DisplayGallow(string[,] gallow)
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
        
        static void Demo()
        {

            var puzzle = new Puzzle();
            string guessedLetter = "";
            puzzle.showGameStats();
            puzzle.showSpacesAndLetters();
            DisplayGallow(puzzle.gameGallow);
            Console.WriteLine("");

            
            Console.WriteLine("Please guess a letter in the puzzle: ");

            // Loop until a valid letter is entered
            while (true)
            {
                guessedLetter = Console.ReadLine();

                // Check if exactly one character is entered
                if (guessedLetter.Length == 1)
                {
                    // Check if the entered character is a letter
                    if (Char.IsLetter(guessedLetter[0]))
                    {
                        // Convert the letter to lowercase
                        guessedLetter = guessedLetter.ToLower();
                        break; // Valid input, exit the loop
                    }
                }

                Console.Clear();
                puzzle.showGameStats();
                puzzle.showSpacesAndLetters();
                DisplayGallow(puzzle.gameGallow);
                Console.WriteLine("");
                Console.WriteLine("Invalid input! Please enter a single letter from the English alphabet:");
            }

            //check if letter was previously guessed (right or wrong)
            
            if (puzzle.IsLetterAlreadyGuessed(guessedLetter))
            {
                Console.WriteLine("You've already guessed that letter. Please try again");
            }
            //if yes
            //clear letterGuessed
            //ask for another input
            //check if letter is in word

            //if yes
            //add to rightLetters
            //if no
            //-1 guessesLeft
            //if guessesLeft == 0;
            //game over
            //add letter to wrongLetters
            //add limb to gallow
            //re-render gamestats, spacesAndLetters, and gameGallow.
            //ask for another input
        }
        
        
        /*
        static void Game()
        {
            var Puzzle = new Puzzle();


            while (Puzzle.guessesLeft != 0)
            {
                try
                {
                    Console.WriteLine("Guesses Remaining = {0} | Wrong Letters Guessed = {1}", Puzzle.guessesLeft, Puzzle.wrongLetters);
                    Console.WriteLine("");

                    DisplayGallow(Puzzle.gameGallow);
                    Console.WriteLine("");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("That is NOT a letter! Press any key to resume");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }

        }
        */

    }
}
