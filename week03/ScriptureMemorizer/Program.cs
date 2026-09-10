/*
 * Scripture Memorizer — Week 03 CSE 210
 *
 * EXCEEDING CORE REQUIREMENTS:
 * 1. Scripture Library: Instead of a single hard-coded scripture, the program
 *    loads a library of scriptures from an external file (scriptures.txt).
 *    Each time the program runs, a random scripture is selected from that library,
 *    giving the user a fresh memorization challenge every session.
 *
 * 2. Only-unhidden selection: When hiding words, the program exclusively selects
 *    from words that have not yet been hidden (the stretch challenge). This means
 *    every key press is guaranteed to hide new words, making the game progress
 *    smoothly without wasted turns.
 *
 * 3. Graceful file-not-found fallback: If scriptures.txt cannot be found, the
 *    program falls back to a built-in default scripture so it still runs correctly.
 */

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Number of words hidden per key press
    private const int WordsHiddenPerTurn = 3;

    static void Main(string[] args)
    {
        Scripture scripture = LoadRandomScripture();

        // Game loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great job memorizing!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(WordsHiddenPerTurn);
        }
    }

    /// <summary>
    /// Loads all scriptures from scriptures.txt (located next to the executable)
    /// and returns one chosen at random. Falls back to a built-in default if the
    /// file cannot be found.
    /// </summary>
    private static Scripture LoadRandomScripture()
    {
        List<Scripture> library = new List<Scripture>();

        // Look for the file next to the running executable
        string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(exeDir, "scriptures.txt");

        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed))
                {
                    continue;
                }

                // Format: Book|chapter|startVerse|endVerse|text
                string[] parts = trimmed.Split('|');
                if (parts.Length < 5)
                {
                    continue;
                }

                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4];

                Reference reference;
                if (startVerse == endVerse)
                {
                    reference = new Reference(book, chapter, startVerse);
                }
                else
                {
                    reference = new Reference(book, chapter, startVerse, endVerse);
                }

                library.Add(new Scripture(reference, text));
            }
        }

        // Fallback if file is missing or empty
        if (library.Count == 0)
        {
            Reference defaultRef = new Reference("John", 3, 16);
            library.Add(new Scripture(defaultRef,
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."));
        }

        Random random = new Random();
        int index = random.Next(library.Count);
        return library[index];
    }
}
