using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an array of Scripture objects
            Scripture[] scriptures = new Scripture[]
            {
                new Scripture("Isaiah 8:13", new string[,] {{"Sanctify", "the", "Lord", "of", "hosts", "himself;", "and", "let", "him", "be", "your", "fear,", "and", "let", "him", "be", "your", "dread"}}),
                new Scripture("1 Peter 5:7", new string[,] {{"Casting", "all", "your", "care", "upon", "him;", "for", "he", "careth", "for", "you."}}),
                new Scripture("John 3:16", new string[,] {{"For", "God", "so", "loved", "the", "world,", "that", "he", "gave", "his", "only", "begotten", "Son,", "that", "whosoever", "believeth", "in", "him", "should", "not", "perish,", "but", "have", "everlasting", "life."}}),
                new Scripture("Genesis 1:1", new string[,] {{"In", "the", "beginning", "God", "created", "the", "heaven", "and", "the", "earth."}}),
                new Scripture("James 1:4", new string[,] {{"But", "let", "patience", "have", "her", "perfect", "work,", "that", "ye", "may", "be", "perfect", "and", "entire,", "wanting", "nothing."}}),
                new Scripture("Revelations 22:21", new string[,] {{"The", "grace", "of", "our", "Lord", "Jesus", "Christ", "be", "with", "you", "all,", "amen."}}),
                new Scripture("Isaiah 1:19", new string[,] {{"If", "ye", "be", "willing", "and", "obedient,", "ye", "shall", "eat", "the", "good", "of", "the", "land."}})
            };

            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Below is a list of some scriptures:");
            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

            // Display a numbered list of available scriptures
            Console.WriteLine("Here is a list of available scriptures:");
            for (int i = 0; i < scriptures.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
            }

            Console.Write("Enter the number of the scripture you want to memorize: ");
            int selection = int.Parse(Console.ReadLine());

            // Display the selected scripture with an animation
            Memorizing memorizing = new Memorizing();
            memorizing.Scripture = scriptures[selection - 1];
            memorizing.Begin();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Occurred: " + ex.Message);
        }
    }
}
