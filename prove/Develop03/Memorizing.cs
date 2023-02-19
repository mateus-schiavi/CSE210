using System;

class Memorizing
{
    public void Begin(Scripture scripture)
    {
        Console.WriteLine("Starting memorization process for:");
        Console.WriteLine(scripture.GetQuotation());
        Console.WriteLine("Reference: " + scripture.GetReference());
        
        // Memorization logic here...
        string[] words = scripture.GetWords();
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine("Please repeat: " + words[i]);
            string response = Console.ReadLine();
            
            // Compare response with expected word
            if (response.ToLower() != words[i].ToLower())
            {
                Console.WriteLine("Incorrect response, please try again.");
                i--;
            }
        }
        
        Console.WriteLine("Congratulations, you have memorized the scripture!");
    }
}
