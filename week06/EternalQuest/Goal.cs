using System;

public abstract class Goal
{
    private readonly string _shortName;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
