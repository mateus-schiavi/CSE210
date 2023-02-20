using System;
using System.Threading;
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
            bool quit = false;
            do
            {
                try
                {
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

                    // Ask if the user wants to save the memorized scripture to a file
                    Console.Write("Do you want to save the memorized scripture to a file? (y/n): ");
                    string saveAnswer = Console.ReadLine().ToLower();
                    if (saveAnswer == "y")
                    {
                        Console.Write("Enter the file name (without extension): ");
                        string fileName = Console.ReadLine();

                        // Create or append to the file with the given name and write the memorized scripture to it
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter($"{fileName}.txt", true))
                        {
                            file.WriteLine($"{selection}. {scriptures[selection - 1].GetText}");
                            file.WriteLine($"{memorizing.Scripture}");
                            file.WriteLine();
                        }

                        Console.WriteLine($"The memorized scripture has been saved to {fileName}.txt");
                    }
                    else if (saveAnswer != "n")
                    {
                        Console.WriteLine("Invalid input. The memorized scripture will not be saved to a file.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An Error Occurred: " + ex.Message);
                }

                // Ask if the user wants to memorize another scripture
                Console.Write("Do you want to memorize another scripture? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "n")
                {
                    quit = true;
                }
                else if (answer != "y")
                {
                    Console.WriteLine("Invalid input. Exiting program.");
                    quit = true;
                }
                else
                {
                    Console.WriteLine();
                }
            } while (!quit);
            Console.WriteLine("Thank you for using the Scripture Memorizer Program. Goodbye!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Occurred: " + ex.Message);
        }
    }
}