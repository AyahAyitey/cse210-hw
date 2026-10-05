// Derived class for running activities
public class Running : Activity
{
    // Unique attribute for running — stored only in this class (not in base)
    private double _distance;

    // Constructor
    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    // Override abstract methods from Activity
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = (distance / minutes) * 60
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = minutes / distance
        return GetMinutes() / _distance;
    }
}
