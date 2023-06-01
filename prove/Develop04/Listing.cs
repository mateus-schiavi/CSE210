using System;
using System.Collections.Generic;
using System.IO;
 
public class Listing : Exercise
{
    private string _message = "This activity will help you reflect on the good things in your life by having you answer a prompt about a certain area.";
    private List<string> _prompts = new List<string>()
    {
        "Think of a challenge you have faced recently. How did you overcome it?",
        "What is something new you have learned recently?",
        "What is a hobby or activity that brings you joy?",
        "Who is someone you have forgiven, and how did it affect your relationship with them?",
        "What is something you accomplished recently that you're proud of?",
        "What is a book, movie, or TV show that has impacted you recently, and why?",
        "Who is someone in your life that you need to thank or show appreciation to, and why?",
        "What is something positive that happened to you today?",
        "What is something that you're looking forward to in the near future?",
        "What is a small act of kindness that someone has done for you recently?",
        "What is something you're grateful for that you often take for granted?",
        "What is a goal you're working towards, and what steps are you taking to achieve it?",
        "What is a memory that always brings a smile to your face?",
        "What is a quote or saying that inspires you, and why?",
        "What is something you have been meaning to do, but keep putting off? How can you take steps to make it happen?",
        "What is something about yourself that you're working to improve?",
        "What is something you've done recently that made someone else's day better?",
        "What is something that always puts you in a good mood?",
        "What is something you appreciate about the natural world around you?",
        "What is something that you are proud of that others might not know about?",
        "What is something that you appreciate about your home or living space?",
        "What is a quality you admire in others, and why?"

    };

    public Listing()
    {
        _exerciseName = "Listing";
        _exerciseResume = _message;
    }

    public void DoListing()
    {
        InitialNotice();
        SetExerciseTime();
        SetClock();

        Random random = new Random();
        int count = 1;

        while (_initialTime < _finalTime)
        {
            Console.Clear();
            Console.WriteLine(_message);
            Console.WriteLine();

            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(count + ". " + prompt);

            Console.WriteLine("Please type your answer below:");
            string answer = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("You entered:");
            Console.WriteLine(answer);
            Console.WriteLine();

            Console.WriteLine("Would you like to save your answer to a file? (Y/N)");
            string saveToFile = Console.ReadLine();

            if (saveToFile.ToLower() == "y")
            {
                Console.WriteLine("Please enter the file name to save your answer (including file extension):");
                string fileName = Console.ReadLine();

                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine(count + ". " + prompt);
                        writer.WriteLine("Date and Time: " + DateTime.Now.ToString());
                        writer.WriteLine(answer);
                    }

                    Console.WriteLine("Your answer has been saved to the file successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving the file: " + ex.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

            count++;
            UpdateClock();
        }

        FinalNotice();
    }
}
