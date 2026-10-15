
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Random random = new Random();
        Fraction fraction5 = new Fraction();

        for (int i = 0; i < 20; i++)
        {
            int top = random.Next(1, 20);
            int bottom = random.Next(1, 20);

            fraction5.SetTop(top);
            fraction5.SetBottom(bottom);

            Console.Write($"Fraction {i + 1}: ");
            Console.Write($"string: {fraction5.GetFractionString()}");
            Console.WriteLine($" Number: {fraction5.GetDecimalValue()}");
        }
    }
}
