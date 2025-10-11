using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
        => $"SimpleGoal:{ShortName}|{Description}|{Points}|{_isComplete}";

    public void ForceComplete() => _isComplete = true;
}
