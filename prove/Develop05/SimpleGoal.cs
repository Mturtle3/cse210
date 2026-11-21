using System;
public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public SimpleGoal(string name, string description, int points, bool completed)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override void Display()
    {
        string status = _completed ? "[X]" : "[ ]";

        Console.WriteLine($"{status} {GetName()} ({GetDescription()})");
    }

    public override int ScoreGoal()
    {
        if (_completed)
        {
            return 0;
        }

        _completed = true;
        return GetPoints();
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal\n{GetName()}\n{GetDescription()}\n{GetPoints()}\n{_completed}";
    }
}