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
                new Scripture("Isaiah 1:19", new string[,] {{"If", "ye", "be", "willing", "and", "obedient,", "ye", "shall", "eat", "the", "good", "of", "the", "land."}}),
                new Scripture("Moses 3:6", new string[,]{{"But", "I,","The", "Lord", "God","spake","and","there","went","up","a","mist","from","the","earth,","and","watered","the","whoe","face","of","the","ground."}}),
                new Scripture("Alma 37:6", new string[,]{{"Now","ye","may","suppose","that","this","is","foolishness","in","me;","but","behold","I","say","unto","you","that","by","small","and","simple","things","are","great","things","brought","to","pass;","and","small","means","in","many","instances","doth","confound","the","wise"}})
            };

            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Below is a list of some scriptures:");
            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

            // Display a numbered list of available scriptures
            Console.WriteLine("Here is a list of available scriptures:");
            // Display a numbered list of available scriptures
            Console.WriteLine("Here is a list of available scriptures:");
            for (int i = 0; i < scriptures.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
            }

            int count = 1;
            bool quit = false;

            do
            {
                try
                {
                    Console.Write("Enter the number of the scripture you want to memorize (or type 'quit' to exit): ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                    {
                        quit = true;
                        break;
                    }

                    int selection = int.Parse(input);

                    // Display the selected scripture with a falling letters animation
                    Memorizing memorizing = new Memorizing();
                    memorizing.Scripture = scriptures[selection - 1];
                    memorizing.Begin();

                    // Save the memorized scripture to a file
                    string fileName = "scriptures.txt";
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine($"Scripture {count}: {memorizing.Scripture.Reference}");
                        for (int i = 0; i < memorizing.Scripture.Words.GetLength(0); i++)
                        {
                            for (int j = 0; j < memorizing.Scripture.Words.GetLength(1); j++)
                            {
                                sw.Write(memorizing.Scripture.Words[i, j] + " ");
                            }
                            sw.WriteLine();
                        }
                        sw.WriteLine(new string('-', 50));
                    }
                    count++;

                    Console.Write("Do you want to memorize another scripture? (y/n): ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "n")
                    {
                        quit = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (!quit);

            Console.ResetColor();

        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Occurred: " + ex.Message);
        }
    }
}