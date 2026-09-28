using System.Text.Json;

public sealed class GoalManager
{
    private const int _recordsPerConsistencyBonus = 5;
    private const int _consistencyBonusPoints = 100;
    private const int _pointsPerLevel = 500;
    private readonly List<Goal> _goals;
    private int _score;
    private int _eventsRecorded;

    public GoalManager()
        : this(0, 0, [])
    {
    }

    private GoalManager(int score, int eventsRecorded, List<Goal> goals)
    {
        _score = score;
        _eventsRecorded = eventsRecorded;
        _goals = goals;
    }

    public IReadOnlyList<Goal> Goals => _goals;
    public int Score => _score;
    public int EventsRecorded => _eventsRecorded;
    public int Level => _score / _pointsPerLevel + 1;

    public string Rank => Level switch
    {
        1 => "Seeker",
        2 => "Pathfinder",
        3 => "Wayfinder",
        4 => "Questkeeper",
        _ => "Eternal Champion"
    };

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public bool TryRecordGoal(
        int index,
        out int pointsEarned,
        out int bonusEarned,
        out bool leveledUp)
    {
        pointsEarned = 0;
        bonusEarned = 0;
        leveledUp = false;
        if (index < 0 || index >= _goals.Count)
        {
            return false;
        }

        Goal goal = _goals[index];
        int previousLevel = Level;
        pointsEarned = goal.RecordEvent();
        if (pointsEarned == 0)
        {
            return true;
        }

        _score += pointsEarned;
        _eventsRecorded++;
        if (_eventsRecorded % _recordsPerConsistencyBonus == 0)
        {
            bonusEarned = _consistencyBonusPoints;
            _score += bonusEarned;
        }

        leveledUp = Level > previousLevel;
        return true;
    }

    public void Save(string filePath)
    {
        SaveData data = new(_score, _eventsRecorded, _goals);
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, json);
    }

    public static GoalManager Load(string filePath)
    {
        string json = File.ReadAllText(filePath);
        SaveData data = JsonSerializer.Deserialize<SaveData>(json)
            ?? throw new InvalidDataException("The save file did not contain valid quest data.");
        return new GoalManager(data.Score, data.EventsRecorded, data.Goals);
    }
}