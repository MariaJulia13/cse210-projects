using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        // Core Requirement 1: Compute the sum of the numbers in the list.
        int sum = numbers.Sum();

        // Core Requirement 2: Compute the average of the numbers in the list.
        double average = numbers.Average();

        // Core Requirement 3: Find the maximum number in the list.
        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenge: Find the smallest positive number closest to zero.
        int smallestPositive = numbers.Where(n => n > 0).Min();

        // Stretch Challenge: Sort the numbers in the list.
        numbers.Sort();

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
