using System;

class Program
{
    static void Main()
    {
        // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function and save the return value
        string userName = PromptUserName();

        // Call PromptUserNumber function and save the return value
        int userNumber = PromptUserNumber();

        // Call SquareNumber function and save the return value
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function with the saved values
        DisplayResult(userName, squaredNumber);
    }

    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt user for name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt user for number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
