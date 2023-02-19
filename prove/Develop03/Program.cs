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
                new Scripture("Isaiah 8:13", "Sanctify the Lord of hosts himself; and let him be your fear, and let him be your dread", new string[] {"Sanctify", "the", "Lord", "of", "hosts", "himself;", "and", "let", "him", "be", "your", "fear,", "and", "let", "him", "be", "your", "dread."}),

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
                Scripture selectedNumber = scriptures[number - 1];

                objMemorize.Begin(selectedNumber);

                Console.WriteLine("Would you like to save this scripture to a file? (y/n)");
                string saveToFile = Console.ReadLine();
                if (saveToFile == "y")
                {
                    Console.WriteLine("Please enter the name of the file to save the scripture to: ");
                    string fileName = Console.ReadLine();
                    string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.WriteAllText(filePath, selectedNumber.GetQuotation());
                    Console.WriteLine($"The scripture has been saved to {filePath}.");
                }

                Console.WriteLine("Would you like to memorize another scripture? (y/n)");
                string again = Console.ReadLine();
                if (again != "y")
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
