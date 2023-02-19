class Word
{
    private string _value;
    private bool _isHidden;

    public Word(string value)
    {
        _value = value;
        _isHidden = true; // By default, the word is hidden
    }

    public string GetValue()
    {
        if (_isHidden)
        {
            return "****"; // Return a string of asterisks if the word is hidden
        }
        else
        {
            return _value;
        }
    }

    public void Show()
    {
        _isHidden = false; // Set the word to be shown
    }

    public void Hide()
    {
        _isHidden = true; // Set the word to be hidden
    }

    public int GetLength()
    {
        return _value.Length; // Return the length of the word
    }

    public string GetWord()
    {
        return _value; // Return the word
    }
}
