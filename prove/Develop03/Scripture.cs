using System;
class Scripture
{
    private string _quotation;
    private string _reference;
    public Scripture()
    {

    }

    public Scripture(string strquotation, string strreference)
    {
        setQuotation(strquotation);
        setReference(strreference);
    }

    public string getQuotation()
    {
        return this._quotation;
    }

    public string getReference()
    {
        return this._reference;
    }

    public void setQuotation(string strquotation)
    {
        this._quotation = strquotation;
    }

    public void setReference(string strreference)
    {
        this._reference = strreference;
    }

    public string Quotation
    {
        get{return this._quotation;}
        set{this._quotation = value;}
    }

    public string Reference
    {
        get{return this._reference;}
        set{this._reference = value;}
    }
}