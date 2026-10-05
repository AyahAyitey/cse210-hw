// Derived class for swimming activities in the lap pool
public class Swimming : Activity
{
    // Unique attribute for swimming — stored only in this class (not in base)
    private int _laps;

    // Constructor
    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Override abstract methods from Activity
    public override double GetDistance()
    {
        // Distance (miles) = laps * 50 meters / 1000 (to km) * 0.62 (to miles)
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = minutes / distance
        return GetMinutes() / GetDistance();
    }
}
