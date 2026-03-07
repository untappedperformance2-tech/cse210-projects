using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Loop for playing multiple games
        while (playAgain == "yes")
        {
            // Generate random magic number from 1 to 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100 inclusive

            int guess = -1;
            int guessCount = 0; // Stretch: count guesses

            // Game loop
            while (guess != magicNumber)
            {
                // Ask for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                // Give hints
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // After correct guess, display number of attempts
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}