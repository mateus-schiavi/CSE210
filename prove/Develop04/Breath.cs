public class Breath : Exercise
{
    private string _breathIn;
    private string _breathOut;

    public Breath()
    {
        _exerciseName = "Breathing";
        _exerciseResume = "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing";
        _breathIn = "Breath in...";
        _breathOut = "Now breathe out...";
    }

    public void DoBreathing()
    {
        InitialNotice();
        SetExerciseTime();
        SetClock();

        GetReady();

        while (_initialTime < _finalTime)
        {
            Console.CursorVisible = false;

            Console.WriteLine($"{_breathIn}");
            Thread.Sleep(2000);

            Console.WriteLine($"{_breathOut}");
            Thread.Sleep(2000);

            Console.WriteLine();
            UpdateClock();
        }

        FinalNotice();
    }

    private void GetReady()
    {
        Console.WriteLine("Get ready to start breathing...");
        Thread.Sleep(2000);
    }
}
