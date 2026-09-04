using System;
using System.Collections.Generic;
using System.IO;

// Journal class models the responsibilities of a journal.
// Responsibility: manage the collection of entries and handle file I/O.
// It does NOT know about menus, prompts, or user input.
class Journal
{
    // Member variables use _underscoreCamelCase
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Display all entries to the console
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write your first entry!");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("========== Journal Entries ==========");
        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("=====================================");
        Console.WriteLine();
    }

    // Save all entries to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to \"{filename}\".");
        Console.WriteLine();
    }

    // Load entries from a file (replaces current entries)
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File \"{filename}\" not found.");
            Console.WriteLine();
            return;
        }

        _entries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (line.Trim() == "") continue;

            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Loaded {_entries.Count} entries from \"{filename}\".");
        Console.WriteLine();
    }

    // Return the number of entries (used by Program for display purposes)
    public int Count => _entries.Count;
}
