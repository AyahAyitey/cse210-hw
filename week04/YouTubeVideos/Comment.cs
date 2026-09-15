/// <summary>
/// Represents a comment left on a YouTube video.
/// Tracks the name of the commenter and the text of their comment.
/// </summary>
public class Comment
{
    private string _commenterName;
    private string _text;

    public string CommenterName
    {
        get { return _commenterName; }
        set { _commenterName = value; }
    }

    public string Text
    {
        get { return _text; }
        set { _text = value; }
    }

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }
}
