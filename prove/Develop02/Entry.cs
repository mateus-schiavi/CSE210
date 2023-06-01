class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    internal static List<string> prompts = new List<string> { "What is your favorite food?",
        "What do you prefer: Ben 10 or Mutant Rex?",
        "Do you prefer Messi or Cristiano Ronaldo?",
        "Do you like Addams Family?",
        "How many physical exercises you have done today?",
        "Do you prefer Android or iOS?",
        "What is the funniest: watch a whole season of Me, my Wife and Kids or watch a stand up?",
        "Do you prefer Naruto or Dragon Ball?",
        "Japanese food or Brazilian food?"};


     
    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }


    public void Display()
    {
        Console.WriteLine("Prompt: " + this.Prompt);
        Console.WriteLine("Response: " + this.Response);
        Console.WriteLine("Date: " + this.Date);
    }


    public static string GetPrompt()
    {
        int option = GetPromptOption();
        return prompts[option];
    }


    private static int GetPromptOption()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Select prompt:");
        Console.ForegroundColor = ConsoleColor.Blue;

        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + prompts[i]);
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        int option;
        Console.WriteLine();
        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > prompts.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 9" + prompts.Count);
        }
        return option - 1;
    }
}