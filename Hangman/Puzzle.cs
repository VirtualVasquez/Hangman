using System;
using System.Collections.Generic;
using System.Linq;


namespace Hangman
{
    public class Puzzle
    {
        public string wordToSolve = "";
        public HashSet<char> uniqueLetters;
        public int guessesLeft = 8;
        public string[,] gameGallow;
        public string[] wrongLetters = new string[7];
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
            uniqueLetters = new HashSet<char>(wordToSolve);
            rightLetters = new string[uniqueLetters.Count];
        }
        public void setWordToSolve()
        {
            string[] possibleWords = new string[]
            {
                    "stack",
                    /*
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
                    */
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

            if (wrongLetters.Any(letter => letter != null))
            {
                foreach (string letter in wrongLetters)
                {
                    Console.Write(letter + " ");
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
            bool isLetterInWrongLetters = Array.Exists(wrongLetters, element => element == letter.ToString());
            bool isLetterInRightLetters = Array.Exists(rightLetters, element => element == letter.ToString());

            return isLetterInWrongLetters || isLetterInRightLetters;
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
        
        public void updateGameGallow()
        {
            switch (guessesLeft)
            {
                case 7:
                    gameGallow[1, 2] = "|";
                    break;
                case 6:
                    gameGallow[2, 2] = "O";
                    break;
                case 5:
                    gameGallow[3, 1] = "/";
                    break;
                case 4:
                    gameGallow[3, 2] = "|";
                    break;
                case 3:
                    gameGallow[3, 3] = "\\";
                    break;
                case 2:
                    gameGallow[4, 1] = "/";
                    break;
                case 1:
                    gameGallow[4, 3] = "\\";
                    break;               
            }
        }
        public void testUpdate()
        {
            gameGallow[1, 2] = "|";
            gameGallow[2, 2] = "O";
            gameGallow[3, 1] = "/";
            gameGallow[3, 2] = "|";
            gameGallow[3, 3] = "\\";
            gameGallow[4, 1] = "/";
            gameGallow[4, 3] = "\\";
        }

    }
}
