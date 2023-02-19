class Word
{
    public char Character { get; }
    public bool IsHidden { get; }

    public Word(char character, bool hidden)
    {
        Character = character;
        IsHidden = hidden;
    }

    public override string ToString()
    {
        return IsHidden ? "_" : Character.ToString();
    }
}
