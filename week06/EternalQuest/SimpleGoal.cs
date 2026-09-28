using System.Text.Json.Serialization;

public sealed class SimpleGoal : Goal
{
    private bool _isComplete;

    [JsonConstructor]
    public SimpleGoal(string description, int points, bool isComplete = false)
        : base(description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}