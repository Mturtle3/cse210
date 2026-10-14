
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string[] prompts =
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "What is something new I learned today?",
            "What is one thing I would like to improve tomorrow?",
            "What made me laugh today?"
        };

        Random random = new Random();

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Find entries by date");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number.");
                choice = 0;
                Console.WriteLine();
                continue;
            }

            if (choice == 1)
            {
                string prompt = prompts[random.Next(prompts.Length)];

                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {
                journal.Save();
            }
            else if (choice == 4)
            {
                journal.Load();
            }
            else if (choice == 5)
            {
                Console.Write("Enter date (e.g., mm/dd/yyyy): ");
                string searchDate = Console.ReadLine();

                journal.FindEntriesByDate(searchDate);
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}
