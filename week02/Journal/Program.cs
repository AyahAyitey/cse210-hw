// =============================================================================
// Journal Program - CSE 210 Week 02
// =============================================================================
// Exceeds Core Requirements:
//   1. STREAK TRACKER: The program tracks how many consecutive days the user
//      has written at least one journal entry. It displays the current streak
//      each time the menu is shown, encouraging daily journaling habits.
//      The streak is saved and loaded alongside journal entries in a separate
//      companion file (<filename>.streak), so it persists between sessions.
//
//   2. ENTRY COUNT FEEDBACK: After writing a new entry the program shows the
//      total number of entries in the journal, giving the user a sense of
//      progress over time.
//
//   3. EXPANDED PROMPT LIST: The program ships with 10 unique writing prompts
//      (double the required minimum of 5) for more variety day-to-day.
// =============================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        // Streak tracking variables (exceeds core requirements)
        int currentStreak = 0;
        string lastEntryDate = "";

        bool running = true;

        Console.WriteLine("Welcome to your Personal Journal!");
        Console.WriteLine();

        while (running)
        {
            DisplayMenu(currentStreak);

            string choice = Console.ReadLine().Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator, ref currentStreak, ref lastEntryDate);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    SaveJournal(journal, currentStreak, lastEntryDate);
                    break;

                case "4":
                    LoadJournal(journal, ref currentStreak, ref lastEntryDate);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for journaling today. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter a number from 1 to 5.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // Display the main menu
    static void DisplayMenu(int streak)
    {
        Console.WriteLine("------------------------------");
        if (streak > 0)
        {
            Console.WriteLine($"  Current Streak: {streak} day{(streak == 1 ? "" : "s")} in a row!");
        }
        Console.WriteLine("  Please select one of the following choices:");
        Console.WriteLine("  1 - Write a new entry");
        Console.WriteLine("  2 - Display the journal");
        Console.WriteLine("  3 - Save the journal to a file");
        Console.WriteLine("  4 - Load the journal from a file");
        Console.WriteLine("  5 - Quit");
        Console.WriteLine("------------------------------");
        Console.Write("> ");
    }

    // Write a new journal entry
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator,
                               ref int streak, ref string lastEntryDate)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        string date = DateTime.Now.ToShortDateString();

        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.WriteLine();

        Entry newEntry = new Entry(date, prompt, response);
        journal.AddEntry(newEntry);

        // Update streak (exceeds core requirements)
        UpdateStreak(date, ref streak, ref lastEntryDate);

        Console.WriteLine($"Entry saved! You now have {journal.Count} total {(journal.Count == 1 ? "entry" : "entries")} in your journal.");
        if (streak > 1)
        {
            Console.WriteLine($"Amazing! You're on a {streak}-day writing streak. Keep it up!");
        }
        Console.WriteLine();
    }

    // Update the consecutive-day streak (exceeds core requirements)
    static void UpdateStreak(string todayDate, ref int streak, ref string lastEntryDate)
    {
        if (lastEntryDate == "")
        {
            // First ever entry
            streak = 1;
            lastEntryDate = todayDate;
            return;
        }

        if (lastEntryDate == todayDate)
        {
            // Already wrote today, streak stays the same
            return;
        }

        // Check if lastEntryDate was yesterday
        DateTime today = DateTime.Parse(todayDate);
        DateTime last = DateTime.Parse(lastEntryDate);
        double daysDiff = (today - last).TotalDays;

        if (daysDiff <= 1.5)
        {
            // Consecutive day
            streak++;
        }
        else
        {
            // Streak broken
            streak = 1;
        }

        lastEntryDate = todayDate;
    }

    // Save journal to file (also saves streak data)
    static void SaveJournal(Journal journal, int streak, string lastEntryDate)
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine().Trim();
        Console.WriteLine();

        if (filename == "")
        {
            Console.WriteLine("No filename entered. Save cancelled.");
            Console.WriteLine();
            return;
        }

        journal.SaveToFile(filename);

        // Save streak companion file (exceeds core requirements)
        string streakFile = filename + ".streak";
        System.IO.File.WriteAllText(streakFile, $"{streak}~|~{lastEntryDate}");
    }

    // Load journal from file (also loads streak data)
    static void LoadJournal(Journal journal, ref int streak, ref string lastEntryDate)
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine().Trim();
        Console.WriteLine();

        if (filename == "")
        {
            Console.WriteLine("No filename entered. Load cancelled.");
            Console.WriteLine();
            return;
        }

        journal.LoadFromFile(filename);

        // Load streak companion file if it exists (exceeds core requirements)
        string streakFile = filename + ".streak";
        if (System.IO.File.Exists(streakFile))
        {
            string[] parts = System.IO.File.ReadAllText(streakFile).Split("~|~");
            if (parts.Length >= 2 && int.TryParse(parts[0], out int savedStreak))
            {
                streak = savedStreak;
                lastEntryDate = parts[1];
                Console.WriteLine($"Streak data loaded: {streak} day{(streak == 1 ? "" : "s")} in a row.");
                Console.WriteLine();
            }
        }
    }
}
