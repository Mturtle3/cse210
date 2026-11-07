using System;
using System.Collections.Generic;
using System.Diagnostics;
public class ReflectingActivity : BaseActivity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity()
        : base("Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Stopwatch timer = Stopwatch.StartNew();

        List<string> remainingQuestions = new List<string>();

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            if (remainingQuestions.Count == 0)
            {
                remainingQuestions = new List<string>(_questions);

                // Shuffle the questions
                for (int i = 0; i < remainingQuestions.Count; i++)
                {
                    int randomIndex = random.Next(i, remainingQuestions.Count);

                    string temp = remainingQuestions[i];
                    remainingQuestions[i] = remainingQuestions[randomIndex];
                    remainingQuestions[randomIndex] = temp;
                }
            }

            string question = remainingQuestions[0];
            remainingQuestions.RemoveAt(0);

            Console.WriteLine();
            Console.WriteLine(question);

            ShowSpinner(5);
        }

        timer.Stop();
        DisplayEndingMessage();
    }
}