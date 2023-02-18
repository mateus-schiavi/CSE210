public class Exercise
{
    protected string _exerciseResume;
    protected string _exerciseName;

    protected int _exerciseTime;
    protected DateTime _finalTime;
    protected DateTime _initialTime;

    public Exercise()
    {

    }

    public Exercise(string exerciseResume, string exerciseName)
    {
        _exerciseName = exerciseName;
        _exerciseResume = exerciseResume;
    }

    public void InitialNotice()
    {
        Console.WriteLine($"Welcome to the {_exerciseName} Exercise\n");
        Console.WriteLine($"{_exerciseResume}");
    }

    public void SetExerciseTime()
    {
        Console.WriteLine("How many time, in seconds, would you like to spend in this exercise?");
        _exerciseTime = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    public void FinalNotice()
    {
        Console.WriteLine();
        Console.WriteLine("Very well!");
        Console.WriteLine($"You have finished another {_exerciseTime} seconds of the {_exerciseName}");
    }

    public void SetClock()
    {
        DateTime initialPeriod = DateTime.Now;
        _finalTime = initialPeriod.AddSeconds(_exerciseTime);
    }

    public void UpdateClock()
    {
        _initialTime = DateTime.Now;
    }

    public void PokeballAnimation()
    {
        Console.CursorVisible = false;
        string[] pokeball = { 
            "    _____    ",
            "  //     \\\\  ",
            " //       \\\\ ",
            "//         \\\\",
            "||  /     \\ ||",
            "|| |       | ||",
            "|| |       | ||",
            "|| |       | ||",
            "||  \\     /  ||",
            " \\\\       // ",
            "  \\\\_____//  "
        };
        for (int i = 0; i < pokeball.Length; i++)
        {
            Console.WriteLine(pokeball[i]);
            Thread.Sleep(100);
        }
    }

    public void GetReady()
    {
        Console.WriteLine("Get ready...");
        PokeballAnimation();
        Console.WriteLine("\n");
    }
}
