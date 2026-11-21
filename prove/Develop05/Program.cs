using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            int level = score / 1000 + 1;

            Console.WriteLine();
            Console.WriteLine($"You have {score} points. You are level {level}.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                DisplayGoals();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
            }

            if (running)
            {
                Console.WriteLine();
                Console.Write("Press Enter to return to the menu...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");

        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        if (choice == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");

            if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.Write("What is the bonus for completing the goal? ");

            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }

            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your goals are:");

        if (goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].Display();
            }
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine();

        if (goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to record.");
            return;
        }

        Console.WriteLine("Your goals are:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].Display();
        }

        Console.Write("\nWhich goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldLevel = score / 1000 + 1;

        int points = goals[choice - 1].ScoreGoal();

        score += points;

        int newLevel = score / 1000 + 1;

        Console.WriteLine($"You earned {points} points!");
        Console.WriteLine($"Your total score is now {score}.");

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"Congratulations! You reached level {newLevel}!");
        }
    }

    static void SaveGoals()
    {
        Console.Write("\nWhat would you like to name the file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);

            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    static void LoadGoals()
    {
        Console.Write("\nWhat is the name of the file you want to load? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            int i = 1;

            while (i < lines.Length)
            {
                string type = lines[i];
                string name = lines[i + 1];
                string description = lines[i + 2];
                int points = int.Parse(lines[i + 3]);

                if (type == "SimpleGoal")
                {
                    bool completed = bool.Parse(lines[i + 4]);

                    loadedGoals.Add(new SimpleGoal(
                        name, description, points, completed));

                    i += 5;
                }
                else if (type == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(
                        name, description, points));

                    i += 4;
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(lines[i + 4]);
                    int target = int.Parse(lines[i + 5]);
                    int completed = int.Parse(lines[i + 6]);

                    loadedGoals.Add(new ChecklistGoal(
                        name, description, points, target, completed, bonus));

                    i += 7;
                }
                else
                {
                    throw new Exception();
                }
            }

            goals = loadedGoals;
            score = loadedScore;

            Console.WriteLine("Goals loaded!");
        }
        catch (Exception)
        {
            Console.WriteLine("There was a problem loading the file.");
        }
    }
}