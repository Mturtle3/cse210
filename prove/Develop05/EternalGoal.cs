using System;
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] {GetName()} ({GetDescription()})");
    }

    public override int ScoreGoal()
    {
        return GetPoints();
    }

    public override string GetSaveString()
    {
        return $"EternalGoal\n{GetName()}\n{GetDescription()}\n{GetPoints()}";
    }
}