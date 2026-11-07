using System;
public class BreathingActivity : BaseActivity
{
    public BreathingActivity()
        : base("Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            double remaining = Duration - (DateTime.Now - startTime).TotalSeconds;

            if (remaining <= 0)
                break;

            int seconds = Math.Min(4, (int)Math.Ceiling(remaining));

            Console.Write("Breathe in...");
            ShowCountDown(seconds);
            Console.WriteLine();

            remaining = Duration - (DateTime.Now - startTime).TotalSeconds;

            if (remaining <= 0)
                break;

            seconds = Math.Min(4, (int)Math.Ceiling(remaining));

            Console.Write("Breathe out...");
            ShowCountDown(seconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
