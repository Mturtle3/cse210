using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        string sign = "";

        Console.Write("What is your grade percentage? ");
        string percentage = Console.ReadLine();
        int percent = int.Parse(percentage);

        int remainder = percent % 10;

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        
        if (remainder >=7 & letter != "A")
        {
            sign = "+";
        }

        else if (remainder < 3)
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}