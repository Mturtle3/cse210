using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : BaseActivity
{
    private List<string> _prompts;
    private List<string> _responses;

    public ListingActivity()
        : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _responses = new List<string>();
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
        Console.WriteLine("You may begin in...");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing your responses. Press Enter after each one.");

        _responses.Clear();

        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }

        timer.Stop();

        Console.WriteLine();
        Console.WriteLine($"You listed {_responses.Count} items!");

        DisplayEndingMessage();
    }
}
