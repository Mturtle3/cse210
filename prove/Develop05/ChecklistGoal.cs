using System;
public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points,
        int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _completed = 0;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points,
        int target, int completed, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _completed = completed;
        _bonus = bonus;
    }

    public override void Display()
    {
        string status = _completed >= _target ? "[X]" : "[ ]";

        Console.WriteLine(
            $"{status} {GetName()} ({GetDescription()}) " +
            $"-- Currently completed: {_completed}/{_target} times");
    }

    public override int ScoreGoal()
    {
        if (_completed >= _target)
        {
            return 0;
        }

        _completed++;

        int points = GetPoints();

        if (_completed == _target)
        {
            points += _bonus;
        }

        return points;
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal\n{GetName()}\n{GetDescription()}\n{GetPoints()}\n{_bonus}\n{_target}\n{_completed}";
    }
}