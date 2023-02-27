using System.Threading;

class Scripture
{
    private string reference;
    private string[,] words;

    public string Reference
    {
        get { return reference; }
        set { reference = value; }
    }

    public string[,] Words
    {
        get { return words; }
        set { words = value; }
    }

    public Scripture(string reference, string[,] words)
    {
        Reference = reference;
        Words = words;
    }

    public string GetText()
    {
        string text = "";
        foreach (string word in Words)
        {
            text += word + " ";
            Thread.Sleep(125);
        }
        return text;
    }
}
