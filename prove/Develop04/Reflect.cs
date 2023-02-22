public class Reflection : Exercise
{
    private string[] _prompts;
    private string _currentPrompt;

    public Reflection()
    {
        _exerciseName = "Reflection";
        _exerciseResume = "This activity will guide you through a reflection exercise. You will be prompted with a question to reflect on, and then given some follow-up questions to consider.";
        _prompts = new string[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    public void DoReflection()
    {
        InitialNotice();
        SetExerciseTime();
        SetClock();

        using (StreamWriter outputFile = new StreamWriter("prompts.txt", true))
        {
            outputFile.WriteLine($"[{DateTime.Now}] Exercise: {_exerciseName}");
            outputFile.WriteLine($"Exercise Time: {_finalTime}");
            outputFile.WriteLine($"Exercise Resume: {_exerciseResume}\n");
        }

        Random random = new Random();

        while (_initialTime < _finalTime)
        {
            Console.Clear();
            Console.CursorVisible = false;
            int index = random.Next(_prompts.Length);
            _currentPrompt = _prompts[index];
            Console.WriteLine($"Prompt: {_currentPrompt}\n");

            using (StreamWriter outputFile = new StreamWriter("prompts.txt", true))
            {
                outputFile.WriteLine($"Prompt: {_currentPrompt}");
            }

            Console.WriteLine("Follow-up Questions:");
            Console.WriteLine("- Why was this experience meaningful to you?");
            Console.WriteLine("- Have you ever done anything like this before?");
            Console.WriteLine("- How did you get started?");
            Console.WriteLine("- How did you feel when it was complete?");
            Console.WriteLine("- What made this time different than other times when you were not as successful?");
            Console.WriteLine("- What is your favorite thing about this experience?");
            Console.WriteLine("- What could you learn from this experience that applies to other situations?");
            Console.WriteLine("- What did you learn about yourself through this experience?");
            Console.WriteLine("- How can you keep this experience in mind in the future?");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            UpdateClock();
        }

        FinalNotice();
    }
}
