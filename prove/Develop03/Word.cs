class Word
{
    private char character;
    private bool isHidden;

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

    public Word(char character, bool isHidden)
    {
        Character = character;
        IsHidden = isHidden;
    }

    public override string ToString()
    {
        return IsHidden ? "_" : Character.ToString();
    }
}
