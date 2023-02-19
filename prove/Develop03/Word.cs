class Word
{
    private char _character;
    private bool _hidden;

    public Word(char character, bool hidden)
    {
        _character = character;
        _hidden = hidden;
    }

    public char GetCharacter()
    {
        return _character;
    }

    public void SetCharacter(char character)
    {
        _character = character;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void SetHidden(bool hidden)
    {
        _hidden = hidden;
    }

    public string GetWord()
    {
        if (_hidden)
        {
            return "_";
        }
        else
        {
            return _character.ToString();
        }
    }
}
