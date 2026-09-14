/// <summary>
/// Represents a single word in a scripture. Each word is responsible for
/// storing its own text and tracking whether it is currently hidden.
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>Returns true if this word has already been hidden.</summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>Hides the word so it displays as underscores.</summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Returns the display representation of the word:
    /// underscores matching the word length when hidden, otherwise the word itself.
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    /// <summary>Returns the raw (unhidden) text of the word.</summary>
    public string GetText()
    {
        return _text;
    }
}
