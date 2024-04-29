using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Guess My Number game!");

        // Core Requirement: Ask the user for the magic number.
        Console.Write("Enter the magic number: ");
        int magicNumber = int.Parse(Console.ReadLine());

        string playAgainResponse;

        // Stretch Challenge: Loop for playing again
        do
        {
            // Initialize variables for tracking guesses
            int numberOfGuesses = 0;
            int guess = 0;

            // Core Requirement: Loop until the guess matches the magic number
            do
            {
                // Core Requirement: Ask the user for a guess.
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                // Determine if the guess is higher, lower, or correct
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
            while (guess != magicNumber);

            // Stretch Challenge: Inform the user of the number of guesses
            Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");

            // Core Requirement: Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgainResponse = Console.ReadLine();

            // Stretch Challenge: Loop back and play again if the user wants to continue
        }
        while (playAgainResponse.ToLower() == "yes");

        Console.WriteLine("Thank you for playing!");
    }
}
