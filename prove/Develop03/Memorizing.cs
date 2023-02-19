class Memorizing
{
    public void Begin(Scripture scripture)
    {
        Console.WriteLine($"Memorize the following scripture:\n{scripture.GetQuotation()}\n");

        string[] words = scripture.GetWords();

        foreach (string word in words)
        {
            foreach (char letter in word)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(100); // pause for 100 milliseconds
            }
            Console.Write(" "); // add a space between words
        }

        Console.WriteLine("\n\nYou have finished memorizing the scripture!");
    }
}
