/// <summary>
/// Represents a complete scripture, combining a Reference and the scripture text.
/// This class is responsible for all scripture-specific behavior: displaying the
/// scripture, hiding random words, and determining when all words are hidden.
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string wordText in text.Split(' '))
        {
            if (!string.IsNullOrWhiteSpace(wordText))
            {
                _words.Add(new Word(wordText));
            }
        }
    }

    /// <summary>
    /// Returns the full display text of the scripture — reference on the first line,
    /// then the scripture text with hidden words replaced by underscores.
    /// </summary>
    public string GetDisplayText()
    {
        List<string> wordDisplays = new List<string>();
        foreach (Word word in _words)
        {
            wordDisplays.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", wordDisplays)}";
    }

    /// <summary>
    /// Hides a specified number of randomly selected words that are not yet hidden.
    /// If fewer unhidden words remain than the requested count, all remaining are hidden.
    /// </summary>
    public void HideRandomWords(int count)
    {
        List<Word> unhiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        int toHide = Math.Min(count, unhiddenWords.Count);
        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    /// <summary>Returns true when every word in the scripture has been hidden.</summary>
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
