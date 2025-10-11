using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = Math.Max(1, target);
        _bonus = Math.Max(0, bonus);
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int earned = Points;

        if (_amountCompleted == _target)
            earned += _bonus;

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
        => $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";

    public void ForceAmountCompleted(int n) => _amountCompleted = Math.Max(0, n);
}
