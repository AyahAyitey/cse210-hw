using System.Text.Json.Serialization;

public sealed class SaveData
{
    [JsonConstructor]
    public SaveData(int score, int eventsRecorded, List<Goal> goals)
    {
        Score = score;
        EventsRecorded = eventsRecorded;
        Goals = goals;
    }

    public int Score { get; }
    public int EventsRecorded { get; }
    public List<Goal> Goals { get; }
}