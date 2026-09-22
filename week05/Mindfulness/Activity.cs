using System;
using System.Threading;

public class Activity
{
    // Shared member variables stored in the base class (rubric: inheriting attributes)
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Accessor for duration so derived classes can check elapsed time
    protected int GetDuration()
    {
        return _duration;
    }

    // Common starting message shared by all activities (rubric: inheriting behaviors)
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // Common ending message shared by all activities (rubric: inheriting behaviors)
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    // Animation: spinner using backspace trick (rubric: pausing/animation)
    public void ShowSpinner(int seconds)
    {
        string[] spinnerChars = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    // Animation: countdown timer with backspace (rubric: pausing/animation)
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            // Erase the digit(s) printed
            int digits = i.ToString().Length;
            for (int d = 0; d < digits; d++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
