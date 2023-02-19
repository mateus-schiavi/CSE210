using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an array of Scripture objects
            Scripture[] scriptures = new Scripture[]
            {
                    new Scripture("Genesis 1:1", "In the Beginning, God created the heaven and the earth", new string[] {"In", "the", "beginning,", "God", "created", "the", "heaven", "and", "the", "earth"}),
            };
            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Below is a list of some scriptures:");
            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

            // Display a numbered list of available scriptures
            Console.WriteLine("Here is a list of available scriptures:");

            for (int i = 0; i < scriptures.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
            }

            // Memorize the selected scripture
            while (true)
            {
                Console.WriteLine("Please choose a scripture to memorize (enter the number), or type 'quit' to exit: ");

                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (!int.TryParse(input, out int number) || number < 1 || number > scriptures.Length)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", scriptures.Length);
                    continue;
                }

                Scripture selectedScripture = scriptures[number - 1];
                Console.WriteLine("Memorizing {0}...", selectedScripture.GetReference());

                for (int i = 0; i < selectedScripture.GetWords().Length; i++)
                {
                    Console.Write(selectedScripture.GetWords()[i] + " ");
                    System.Threading.Thread.Sleep(500); // wait for half a second before displaying the next word
                }
                Console.WriteLine();

                Memorizing objMemorize = new Memorizing();
                objMemorize.Begin(selectedScripture);

                Console.WriteLine("Would you like to save this scripture to a file? (y/n)");
                string saveToFile = Console.ReadLine().ToLower();

                if (saveToFile == "y")
                {
                    Console.WriteLine("Please enter the file name:");
                    string fileName = Console.ReadLine();
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(selectedScripture.GetReference());
                        
                    }
                    Console.WriteLine("Scripture saved to file successfully!");
                }

                Console.WriteLine("Would you like to memorize another scripture? (y/n)");
                string repeat = Console.ReadLine().ToLower();

                if (repeat == "n")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (repeat != "y")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Occurred" + ex.Message);
        }
    }
}
