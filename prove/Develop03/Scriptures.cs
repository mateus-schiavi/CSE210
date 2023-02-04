
class Scriptures
{
    private string _mention;
    private string _quotation;

    public Scriptures()
    {

    }

    public Scriptures(string _mention, string _quotation)
    {
        setMention(_mention);
        setQuotation(_quotation);
    }

    public void setMention(string strMention)
    {
        this._mention = strMention;
    }

    public void setQuotation(string strQuotation)
    {
        this._quotation = strQuotation;
    }

    public string Mention
    {
        get{return this._mention;}
        set{this._mention = value;}
    }

    public string Quotation
    {
        get{return this._quotation;}
        set{this._quotation = value;}
    }

    public string[] getVersicles()
    {
        return _quotation.Split("\n");
    }
}