public abstract class Exercise
{
    public string _exerciseName { get; protected set; }
    public string _exerciseResume { get; protected set; }
    protected int _initialTime { get; set; }
    protected int _finalTime { get; set; }

    protected void InitialNotice()
    {
        Console.Clear();
        Console.WriteLine($"Get ready for the {_exerciseName} exercise!");
        Console.WriteLine($"{_exerciseResume}\n");
    }

    protected void FinalNotice()
    {
        Console.WriteLine($"\nGreat job! You completed the {_exerciseName} exercise!");
    }

    protected void SetExerciseTime()
    {
        Console.WriteLine("How many seconds would you like to spend on this exercise?");
        int time = int.Parse(Console.ReadLine());
        _initialTime = 0;
        _finalTime = time;
    }

    protected void SetClock()
    {
        Console.WriteLine("\nStarting in...");
        for (int counter = 3; counter >= 1; counter--)
        {
            Console.WriteLine($"{counter}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Go!");
    }

    protected void UpdateClock()
    {
        _initialTime += 10;
        Console.WriteLine($"Time left: {_finalTime - _initialTime} seconds");
        Thread.Sleep(3000);
    }
}
