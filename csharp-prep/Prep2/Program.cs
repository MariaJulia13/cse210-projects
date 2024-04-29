using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Determine the letter grade
        char letter;

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Determine the sign
        string sign = "";

        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7 && letter != 'F')
        {
            sign = "+";
        }
        else if (lastDigit < 3 && letter != 'A' && letter != 'F')
        {
            sign = "-";
        }

        // Determine if the user passed the course
        bool passed = gradePercentage >= 70;

        // Print the appropriate message
        if (passed)
        {
            Console.WriteLine($"Congratulations! You passed with a grade of {letter}{sign}.");
        }
        else
        {
            Console.WriteLine($"Sorry, you did not pass. Keep working hard for next time!");
        }

        // Display the letter grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
    }
}
