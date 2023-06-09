using System;
using System.Linq;


namespace Hangman
{
    public class Puzzle
    {
        public string wordToSolve = "";
        public int guessesLeft = 8;
        public string[,] gameGallow;
        public char[] wrongLetters = new char[7];
        public string[] rightLetters;

        public Puzzle()
        {
            gameGallow = BaseGallow();
            setWordToSolve();
        }

        public string[,] BaseGallow()
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
                if (Array.IndexOf(rightLetters, letter.ToString()) != -1)
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public void showGameStats()
        {
            Console.WriteLine("Guesses Left = {0}", guessesLeft);
            Console.WriteLine("");
            Console.WriteLine("Letters Guessed:");

            if (wrongLetters.Any(letter => letter != '\0'))
            {
                foreach (char letter in wrongLetters)
                {
                    Console.Write(letter + ", ");
                }
            }
            else
            {
                Console.WriteLine("(You haven't made any wrong guesses yet.)");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        public bool IsLetterAlreadyGuessed(string userInput)
        {
            char letter = userInput[0];
            if (wrongLetters.Contains(letter) || rightLetters.Contains(letter.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsLetterInPuzzle(string userInput)
        {
            char letter = userInput[0];
            if (wordToSolve.Contains(letter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
