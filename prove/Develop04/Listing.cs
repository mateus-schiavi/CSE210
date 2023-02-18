using System;
using System.Collections.Generic;
using System.IO;

public class Listing : Exercise
{
    private string _message = "This activity will help you reflect on the good things in your life by having you answer a prompt about a certain area.";
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
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

        SetClock();

        Random random = new Random();

        while (_initialTime < _finalTime)
        {
            Console.Clear();
            Console.WriteLine(_message);
            Console.WriteLine();

            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);

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
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine("Question: " + prompt);
                        writer.WriteLine("Answer: " + answer);
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

            UpdateClock();
        }

        FinalNotice();
    }
}
