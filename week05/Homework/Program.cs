using System;

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public int ID { get; set; }

    public virtual double CalculatePay()
    {
        return 0;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Employee: {Name}, ID: {ID}");
    }
}

public class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public override double CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}

public class Program
{
    public static void Main()
    {
        var employee = new HourlyEmployee
        {
            Name = "Alice",
            ID = 101,
            HourlyRate = 25.50,
            HoursWorked = 40
        };

        employee.DisplayInfo();
        Console.WriteLine($"Weekly pay: ${employee.CalculatePay():F2}");
    }
}
