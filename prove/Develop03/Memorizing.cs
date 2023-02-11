using System;

class Memorizing
{
    public void Begin(Scripture scripture)
    {
        Console.WriteLine("Starting memorization process for:");
        Console.WriteLine(scripture.Quotation);
        Console.WriteLine("Reference: " + scripture.Reference);
    }
}