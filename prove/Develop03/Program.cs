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
                new Scripture("Isaiah 8:13", "Sanctify the Lord of hosts himself; and let him be your fear, and let him be your dread", new string[] {"Sanctify", "the", "Lord", "of", "hosts", "himself;", "and", "let", "him", "be", "your", "fear,", "and", "let", "him", "be", "your", "dread."}),
                new Scripture("1 Peter 5:7", "Casting all your care upon him; for he careth for you.", new string[] {"Casting", "all", "your", "care", "upon", "him;", "for", "he", "careth", "for", "you."}),
                new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.", new string[] {"For", "God", "so", "loved", "the", "world,", "that", "he", "gave", "his", "only", "begotten", "Son,", "that", "whosoever", "believeth", "in", "him", "should", "not", "perish,", "but", "have", "everlasting", "life."}),
                new Scripture("Genesis 1:1", "In the Beginning, God created the heaven and the earth", new string[] {"In", "the", "beginning,", "God", "created", "the", "hevaen", "and", "the", "earth"}),
                new Scripture("Genesis 1:1", "In the Beginning, God created the heaven and the earth", new string[] {"In", "the", "beginning,", "God", "created", "the", "hevaen", "and", "the", "earth"}),
                new Scripture("James 1:4","But let patience have her perfect work, that ye may be perfect and entire, wanting nothing", new string[] {"But", "let","patience","have","her","perfect","work,","that","ye","may","be","perfect","and","entire", "wanting","nothing"}),
                new Scripture("Revelations 22:21", "The grace of our Lord Jesus Christ be with you all, amen.", new string[] {"The", "grace", "of", "our", "Lord", "Jesus", "Christ", "be", "with","you", "all", "amen."}),
                new Scripture("Isaiah 1:19","If ye be willing and obedient, ye shall eat the good of the land", new string[]{"If","ye","be","willing","and","obedient","ye","shall","eat","the","good","of","the","land"})
            };

            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Below is a list of some scriptures:");
            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

            // Display a numbered list of available scriptures
            for (int i = 0; i < scriptures.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetQuotation()}");
            }

            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");
            Console.WriteLine("Please choose a scripture to memorize (Enter the number): ");

            int choice = int.Parse(Console.ReadLine());
            Scripture selectedScripture = scriptures[choice - 1];

            Memorizing objMemorize = new Memorizing();
            objMemorize.Begin(selectedScripture);

            // Ask the user if they would like to memorize another scripture
            Console.WriteLine("Would you like to memorize another scripture? (y/n)");
            string repeat = Console.ReadLine();

            while (true)
        {
            Console.WriteLine("Please choose a scripture to memorize (Enter the number), or type 'quit' to exit: ");

            string input = Console.ReadLine();
            if (input == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            int number = int.Parse(input);
            Scripture selectedNumber = scriptures[choice - 1];

            Memorizing objMemo = new Memorizing();
            objMemorize.Begin(selectedScripture);

            Console.WriteLine("Would you like to memorize another scripture? (y/n)");
            string Again = Console.ReadLine();
            if (Again != "y")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Has Occurred " + ex.Message);
        }
    }
}
