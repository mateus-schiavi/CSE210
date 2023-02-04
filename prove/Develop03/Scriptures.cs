
public class Scripture
{
    public string Mention { get; set; }
    public string Quotation { get; set; }

    public Scripture(string mention, string quotation)
    {
        Mention = mention;
        Quotation = quotation;
    }

    public string[] GetVersicles()
    {
        return Quotation.Split(new[] { "\n" }, StringSplitOptions.None);
    }
}
