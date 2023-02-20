class Scripture
{
    public string Reference { get; set; }
    public string[,] Words { get; set; }

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
            Thread.Sleep(500);
        }
        return text;
    }
}
