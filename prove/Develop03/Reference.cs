using System;
using System.IO;

public class Reference
{ 
    private string _stamp;
    private string _section;
    private string _firstQuote;
    private string _finalQuote;

    public Reference()
    {

    }

    public Reference(string stamp, string section, string firstQuote, string finalQuote)
    {
        _stamp = stamp;
        _section = section;
        _firstQuote = firstQuote;
        _finalQuote = finalQuote;
    }

    public string Stamp
    {
        get { return _stamp; }
        set { _stamp = value; }
    }

    public string Section
    {
        get { return _section; }
        set { _section = value; }
    }

    public string FirstQuote
    {
        get { return _firstQuote; }
        set { _firstQuote = value; }
    }

    public string FinalQuote
    {
        get { return _finalQuote; }
        set { _finalQuote = value; }
    }
}
