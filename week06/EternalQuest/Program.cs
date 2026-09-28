using System.Globalization;

public static class Program
{
    private const string _saveFilePath = "eternal-quest-save.json";

    public static void Main()
    {
        // Creativity extension: score-based ranks and a 100-point consistency bonus every five recorded events.
        GoalManager manager = new();
        Console.WriteLine("=== Eternal Quest ===");
        Console.WriteLine("Track your goals, earn points, and rise through the ranks.");
        RunMenu(manager);
    }

    private static void RunMenu(GoalManager manager)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {manager.Score} | Level {manager.Level}: {manager.Rank}");
            Console.WriteLine("1. Show goals");
            Console.WriteLine("2. Create a goal");
            Console.WriteLine("3. Record a goal event");
            Console.WriteLine("4. Show quest status");
            Console.WriteLine("5. Save quest");
            Console.WriteLine("6. Load quest");
            Console.WriteLine("0. Quit");
            int choice = ReadInt("Choose an option: ", 0, 6);

            switch (choice)
            {
                case 1:
                    ShowGoals(manager);
                    break;
                case 2:
                    CreateGoal(manager);
                    break;
                case 3:
                    RecordGoal(manager);
                    break;
                case 4:
                    ShowQuestStatus(manager);
                    break;
                case 5:
                    SaveQuest(manager);
                    break;
                case 6:
                    manager = LoadQuest(manager);
                    break;
                case 0:
                    running = false;
                    break;
            }
        }

        Console.WriteLine("Your quest is saved whenever you choose Save Quest. See you next time!");
    }

    private static void ShowGoals(GoalManager manager)
    {
        if (manager.Goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one to begin your quest.");
            return;
        }

        Console.WriteLine("Your goals:");
        for (int index = 0; index < manager.Goals.Count; index++)
        {
            Goal goal = manager.Goals[index];
            Console.WriteLine($"{index + 1}. {goal.GetStatus()} {goal.Description} ({goal.Points} points)");
        }
    }

    private static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Goal type: 1. Simple  2. Eternal  3. Checklist");
        int type = ReadInt("Choose a type: ", 1, 3);
        string description = ReadNonEmpty("Goal description: ");
        int points = ReadInt("Points per event: ", 1, int.MaxValue);

        Goal goal = type switch
        {
            1 => new SimpleGoal(description, points),
            2 => new EternalGoal(description, points),
            3 => new ChecklistGoal(
                description,
                points,
                ReadInt("Number of completions required: ", 1, int.MaxValue),
                ReadInt("Completion bonus points: ", 0, int.MaxValue)),
            _ => throw new InvalidOperationException("Unknown goal type.")
        };

        manager.AddGoal(goal);
        Console.WriteLine("Goal created.");
    }

    private static void RecordGoal(GoalManager manager)
    {
        if (manager.Goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording progress.");
            return;
        }

        ShowGoals(manager);
        int selected = ReadInt("Which goal did you accomplish? ", 1, manager.Goals.Count) - 1;
        Goal selectedGoal = manager.Goals[selected];
        if (!manager.TryRecordGoal(selected, out int points, out int bonus, out bool leveledUp))
        {
            Console.WriteLine("That goal could not be recorded.");
            return;
        }

        if (points == 0)
        {
            Console.WriteLine("That goal is already complete; no additional points were awarded.");
            return;
        }

        Console.WriteLine($"Recorded: {selectedGoal.Description}. +{points} points.");
        if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete)
        {
            Console.WriteLine("Checklist complete! The completion bonus is included above.");
        }

        if (bonus > 0)
        {
            Console.WriteLine($"Consistency bonus: +{bonus} points for {manager.EventsRecorded} recorded events.");
        }

        if (leveledUp)
        {
            Console.WriteLine($"Rank up! You are now level {manager.Level}: {manager.Rank}.");
        }
    }

    private static void ShowQuestStatus(GoalManager manager)
    {
        Console.WriteLine($"Total score: {manager.Score}");
        Console.WriteLine($"Rank: Level {manager.Level} {manager.Rank}");
        Console.WriteLine($"Recorded events: {manager.EventsRecorded}");
        Console.WriteLine($"Goals created: {manager.Goals.Count}");
    }

    private static void SaveQuest(GoalManager manager)
    {
        try
        {
            manager.Save(_saveFilePath);
            Console.WriteLine($"Quest saved to {Path.GetFullPath(_saveFilePath)}");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not save the quest: {exception.Message}");
        }
    }

    private static GoalManager LoadQuest(GoalManager currentManager)
    {
        if (!File.Exists(_saveFilePath))
        {
            Console.WriteLine($"No save file found at {Path.GetFullPath(_saveFilePath)}");
            return currentManager;
        }

        try
        {
            GoalManager loadedManager = GoalManager.Load(_saveFilePath);
            Console.WriteLine("Quest loaded successfully.");
            return loadedManager;
        }
        catch (Exception exception) when (exception is IOException or System.Text.Json.JsonException or InvalidDataException)
        {
            Console.WriteLine($"Could not load the quest: {exception.Message}");
            return currentManager;
        }
    }

    private static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadInt(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                && value >= minimum
                && value <= maximum)
            {
                return value;
            }

            Console.WriteLine($"Enter a whole number from {minimum} to {maximum}.");
        }
    }
}