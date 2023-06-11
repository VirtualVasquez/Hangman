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

            while (puzzle.guessesLeft != 0)
            {
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
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Please enter a single letter from the English alphabet.");
                    Console.WriteLine("Press any key to resume");
                    Console.ReadLine();
                    Console.Clear();

                    puzzle.showGameStats();
                    puzzle.showSpacesAndLetters();
                    DisplayGallow(puzzle.gameGallow);
                    Console.WriteLine("");
                    Console.WriteLine("Please guess a letter in the puzzle: ");
                }

                //check if guessedLetter was previously guessed (right or wrong)            
                if (puzzle.IsLetterAlreadyGuessed(guessedLetter))
                {
                    Console.Clear();
                    Console.WriteLine("You've already guessed that letter. Please try again");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                    
                }

                //check if guessedLetter is in wordToGuess
                if (puzzle.IsLetterInPuzzle(guessedLetter))
                {
                    //if yes
                    // Find the first occurrence of null in the rightLetters array
                    int index = Array.IndexOf(puzzle.rightLetters, null);

                    // Assign the new letter to the first null index in rightLetters
                    if (index != -1)
                    {
                        puzzle.rightLetters[index] = guessedLetter;
                    }

                    //check if all needed letters are present in rightletter
                    int nullCheck = Array.IndexOf(puzzle.rightLetters, null);

                    if (nullCheck == -1)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations! You've won!");
                        Console.ReadLine();
                        //break;  
                    }
                }

                //if guessedLetter is not in wordToGuess
                else
                {
                    //-1 guessesLeft
                    puzzle.guessesLeft--;

                    //if no more guesses, game over
                    if (puzzle.guessesLeft == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Game Over!");
                        Console.ReadLine();
                        Console.Clear();
                        //break;
                    }

                    //find first occurrence of null in the wrongLetters array.
                    int index = Array.IndexOf(puzzle.wrongLetters, null);

                    //Assign the new to the first null index in wrongLetters
                    if (index != -1)
                    {
                        puzzle.wrongLetters[index] = guessedLetter;
                    }
                    //add limb to gallow
                    puzzle.updateGameGallow();
                }

                Console.WriteLine("");
                Console.WriteLine("Press Enter to resume!");
                guessedLetter = "";
                Console.ReadLine();
                Console.Clear();

            }


            //re-render gamestats, spacesAndLetters, and gameGallow.
            //ask for another input
        }
    }
}
