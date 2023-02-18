public abstract class Exercise
{
    protected string _exerciseName;
    protected string _exerciseResume;
    protected int _initialTime;
    protected int _finalTime;

    public string ExerciseName
    {
        get { return _exerciseName; }
    }

    public string ExerciseResume
    {
        get { return _exerciseResume; }
    }

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
        Console.WriteLine("How many minutes would you like to spend on this exercise?");
        int time = int.Parse(Console.ReadLine());
        _initialTime = 0;
        _finalTime = time * 60;
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
        Console.WriteLine($"Time left: {_finalTime % 60} seconds");
        Thread.Sleep(10000);
    }
}
