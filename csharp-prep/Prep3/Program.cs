using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let's play Guess My Number");

        string keep_playing = "yes";

        while (keep_playing == "yes")
        {
            Random random = new Random();
            int secret_number = random.Next(1, 101);
            Console.WriteLine($"The secret number is {secret_number}: ");

            int guess_count = 0;
            int guess = -1;

            while (guess != secret_number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guess_count += 1;

                if (guess > secret_number)
                {
                    Console.WriteLine("Lower");
                }

                else if (guess < secret_number)
                {
                    Console.WriteLine("Higher");
                }

                else
                {
                    Console.WriteLine("You guessed it.");
                }
            }

            Console.WriteLine();

            Console.WriteLine($"It took you {guess_count} guesses.");

            Console.Write("Would you like to play again? (yes or no) ");
            keep_playing = Console.ReadLine();
        }
    }
}