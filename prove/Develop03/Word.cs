class Word
{
    private char character;
    private bool isHidden;
    private bool isWordHidden;

    public char Character
    {
        get { return character; }
        set { character = value; }
    }

    public bool IsHidden
    {
        get { return isHidden; }
        set { isHidden = value; }
    }

    public bool IsWordHidden
    {
        get { return isWordHidden; }
        set { isWordHidden = value; }
    }

    public Word(char character, bool isHidden, bool isWordHidden)
    {
        Character = character;
        IsHidden = isHidden;
        IsWordHidden = isWordHidden;
    }

    public override string ToString()
    {
        if (IsWordHidden)
        {
            return new string('_', 1 + (IsHidden ? 0 : 1));
        }
        else
        {
            return IsHidden ? "_" : Character.ToString();
        }
    }
}
