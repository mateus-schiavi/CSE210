using System;
using System.Collections.Generic;

public class Listing : Exercise
{
    private string _message = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
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

            foreach (string prompt in _prompts)
            {
                Console.WriteLine(prompt);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Why was this experience meaningful to you?");
                Console.WriteLine("Have you ever done anything like this before?");
                Console.WriteLine("How did you get started?");
                Console.WriteLine("How did you feel when it was complete?");
                Console.WriteLine("What made this time different than other times when you were not as successful?");
                Console.WriteLine("What is your favorite thing about this experience?");
                Console.WriteLine("What could you learn from this experience that applies to other situations?");
                Console.WriteLine("What did you learn about yourself through this experience?");
                Console.WriteLine("How can you keep this experience in mind in the future?");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
            }

            UpdateClock();
        }

        FinalNotice();
    }
}
