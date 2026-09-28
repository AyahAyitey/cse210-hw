using System.Text.Json.Serialization;

public sealed class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonusPoints;
    private int _completedCount;

    [JsonConstructor]
    public ChecklistGoal(
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int completedCount = 0)
        : base(description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = completedCount;
    }

    public int TargetCount => _targetCount;
    public int BonusPoints => _bonusPoints;
    public int CompletedCount => _completedCount;
    public override bool IsComplete => _completedCount >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _completedCount++;
        return Points + (IsComplete ? _bonusPoints : 0);
    }

    public override string GetStatus()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} (Completed {_completedCount}/{_targetCount} times)";
    }
}