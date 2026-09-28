using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "goalType")]
[JsonDerivedType(typeof(SimpleGoal), "simple")]
[JsonDerivedType(typeof(EternalGoal), "eternal")]
[JsonDerivedType(typeof(ChecklistGoal), "checklist")]
public abstract class Goal
{
    private readonly string _description;
    private readonly int _points;

    protected Goal(string description, int points)
    {
        _description = description;
        _points = points;
    }

    public string Description => _description;
    public int Points => _points;
    public abstract bool IsComplete { get; }

    public abstract int RecordEvent();

    public abstract string GetStatus();
}