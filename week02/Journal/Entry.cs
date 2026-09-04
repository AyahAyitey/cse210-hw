using System;

// Entry class models a single journal entry.
// Responsibility: store the date, prompt, and response for one entry.
// It does NOT know about the list of entries, file I/O, or menus.
class Entry
{
    // Member variables use _underscoreCamelCase
    private string _date;
    private string _prompt;
    private string _body;

    // Constructor
    public Entry(string date, string prompt, string body)
    {
        _date = date;
        _prompt = prompt;
        _body = body;
    }

    // Properties
    public string Date => _date;
    public string Prompt => _prompt;
    public string Body => _body;

    // Display the entry to the console
    public void Display()
    {
        Console.WriteLine($"Date:   {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Entry:  {_body}");
        Console.WriteLine();
    }

    // Serialize the entry to a single line using ~|~ as a separator
    // so that commas and pipes in content don't break parsing
    public string ToFileString()
    {
        return $"{_date}~|~{_prompt}~|~{_body}";
    }

    // Parse a line from the file back into an Entry object
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("~|~");
        // Guard against malformed lines
        if (parts.Length < 3)
            return null;

        return new Entry(parts[0], parts[1], parts[2]);
    }
}
