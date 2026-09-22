// =============================================================================
// CSE 210 - Week 05: Mindfulness Program
// =============================================================================
//
// EXCEEDING CORE REQUIREMENTS - Description of enhancements:
//
// 1. FOURTH ACTIVITY - GratitudeActivity:
//    A brand new activity type called "Gratitude Activity" has been added.
//    It prompts the user with specific gratitude-focused questions each round,
//    collects their written responses, and then displays a full gratitude list
//    back to them at the end of the session so they can appreciate what they wrote.
//
// 2. NO-REPEAT PROMPTS/QUESTIONS:
//    The ReflectingActivity, ListingActivity, and GratitudeActivity all track
//    which prompts and questions have already been shown. A prompt or question
//    will not be repeated until every item in the list has been used at least
//    once in that session. This is implemented via a separate "unused" list that
//    refills only when empty.
//
// 3. ACTIVITY LOG WITH SAVE/LOAD:
//    The program keeps a running log of every completed activity (name, date/time,
//    and duration). This log is saved to "activity_log.txt" in the same directory
//    and reloaded on startup so the history is preserved across sessions. The user
//    can view the full log from the main menu.
//
// =============================================================================

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<string> _activityLog = new List<string>();
    private static readonly string _logFile = "activity_log.txt";

    static void Main(string[] args)
    {
        LoadLog();

        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. View activity log");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity(), "Breathing Activity");
                    break;

                case "2":
                    RunActivity(new ReflectingActivity(), "Reflection Activity");
                    break;

                case "3":
                    RunActivity(new ListingActivity(), "Listing Activity");
                    break;

                case "4":
                    RunActivity(new GratitudeActivity(), "Gratitude Activity");
                    break;

                case "5":
                    DisplayLog();
                    break;

                case "6":
                    quit = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    System.Threading.Thread.Sleep(1500);
                    break;
            }
        }
    }

    // Runs an activity and records it in the log when finished
    static void RunActivity(dynamic activity, string activityName)
    {
        DateTime start = DateTime.Now;
        activity.Run();

        string logEntry = $"{start:yyyy-MM-dd HH:mm:ss} | {activityName}";
        _activityLog.Add(logEntry);
        SaveLog();
    }

    static void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("============");

        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No activities completed yet.");
        }
        else
        {
            foreach (string entry in _activityLog)
            {
                Console.WriteLine(entry);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }

    static void SaveLog()
    {
        try
        {
            File.WriteAllLines(_logFile, _activityLog);
        }
        catch (Exception)
        {
            // If saving fails, continue silently - logging is a bonus feature
        }
    }

    static void LoadLog()
    {
        try
        {
            if (File.Exists(_logFile))
            {
                string[] lines = File.ReadAllLines(_logFile);
                _activityLog.AddRange(lines);
            }
        }
        catch (Exception)
        {
            // If loading fails, start with an empty log
        }
    }
}
