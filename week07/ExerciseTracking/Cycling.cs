// Derived class for stationary bicycle activities
public class Cycling : Activity
{
    // Unique attribute for cycling — stored only in this class (not in base)
    private double _speed;

    // Constructor
    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    // Override abstract methods from Activity
    public override double GetDistance()
    {
        // Distance (miles) = (speed / 60) * minutes
        return (_speed / 60) * GetMinutes();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = 60 / speed
        return 60 / _speed;
    }
}
