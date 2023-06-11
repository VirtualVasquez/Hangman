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
            GameInstructions.Intro();
            Game();
        }
        
        static void Game()
        {

            var puzzle = new Puzzle();
            string guessedLetter = "";

            while (puzzle.guessesLeft != 0)
            {
                puzzle.showGameStats();
                puzzle.showSpacesAndLetters();
                CommonFunctions.DisplayGallow(puzzle.gameGallow);
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
                    CommonFunctions.DisplayGallow(puzzle.gameGallow);
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

                //if guessedLetter is in wordToGuess
                if (puzzle.IsLetterInPuzzle(guessedLetter))
                {
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
                        break;
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

                guessedLetter = "";
                Console.Clear();

            }
        }
    }
}
