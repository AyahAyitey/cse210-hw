using System.Text.Json.Serialization;

public sealed class EternalGoal : Goal
{
    [JsonConstructor]
    public EternalGoal(string description, int points)
        : base(description, points)
    {
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetStatus()
    {
        return "[ ] (ongoing)";
    }
}