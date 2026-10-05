// Base class for all exercise activities
public abstract class Activity
{
    // Private member variables (encapsulation)
    private string _date;
    private int _minutes;

    // Constructor
    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Getters for shared attributes (used by derived classes and GetSummary)
    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods — declared here, implemented in each derived class
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method that builds the summary string using the abstract methods above
    // This works polymorphically because GetDistance/GetSpeed/GetPace are overridden
    public virtual string GetSummary()
    {
        string type = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{_date} {type} ({_minutes} min) - Distance: {distance:0.0} miles, " +
               $"Speed: {speed:0.0} mph, Pace: {pace:0.0} min per mile";
    }
}
