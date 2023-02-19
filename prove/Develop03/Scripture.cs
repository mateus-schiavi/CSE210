using System;

class Scripture
{
    private string _quotation;
    private string _reference;
    private string[] _words;

    public Scripture(string quotation, string reference, string[] words)
    {
        _quotation = quotation;
        _reference = reference;
        _words = words;
    }

    public string GetQuotation()
    {
        return _quotation;
    }

    public void SetQuotation(string quotation)
    {
        _quotation = quotation;
    }

    public string GetReference()
    {
        return _reference;
    }

    public void SetReference(string reference)
    {
        _reference = reference;
    }

    public string[] GetWords()
    {
        return _words;
    }

    public void SetWords(string[] words)
    {
        _words = words;
    }
}
