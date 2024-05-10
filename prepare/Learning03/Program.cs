using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances using different constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(6, 7);

        // Output representations of fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Test getters and setters - not applicable since the provided class doesn't have them

        Console.ReadLine();
    }
}
