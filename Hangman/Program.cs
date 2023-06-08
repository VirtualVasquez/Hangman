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

            puzzle.showSpacesAndLetters();
            DisplayGallow(puzzle.gameGallow);

            Console.ReadLine();
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
        class Puzzle
        {
            public string wordToSolve = "";
            public int guessesLeft = 8;
            public int wrongGuesses = 0;
            public string[,] gameGallow;
            public string[] wrongLetters = new string[7];
            public string[] rightLetters;

            public Puzzle()
            {
                gameGallow = BaseGallow();
                setWordToSolve();
            }
            public void setRightLettersLength()
            {
                rightLetters = new string[wordToSolve.Length];
            }
            public void setWordToSolve()
            {
                string[] possibleWords = new string[]
                {
                    "stack",
                    "proxy",
                    "query",
                    "object",
                    "domain",
                    "memory",
                    "browser",
                    "compile",
                    "website",
                    "database",
                    "internet",
                    "response",
                    "algorithm",
                    "hyperlink",
                    "developer",
                    "validation",
                    "attachment",
                    "defragment",
                    "programming",
                    "application",
                    "compression",
                    "architecture",
                    "alphanumeric",
                    "architecture",
                    "microcomputer",
                    "compatability"
                };
                Random random = new Random();
                int randomIndex = random.Next(0, possibleWords.Length);
                wordToSolve = possibleWords[randomIndex];
                setRightLettersLength();
            }
            public void showSpacesAndLetters()
            {
                Console.Write("Your word: ");
                foreach (char letter in wordToSolve)
                {
                    if (rightLetters.Contains(letter.ToString()))
                    {
                        Console.Write(letter + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine("");
            }
        }

    }
}
