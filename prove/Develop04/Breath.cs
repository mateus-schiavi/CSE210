public class Breath : Exercise
{
    private string _breatheIn;
    private string _breatheOut;

    public Breath()
    {
        _exerciseName = "Breathing";
        _exerciseResume = "This activity will help you to control your chakra by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing";
        _breatheIn = "Breathe in...";
        _breatheOut = "Now breathe out...";
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

            Console.WriteLine($"{_breatheIn}");
            Thread.Sleep(4000);

            Console.WriteLine($"{_breatheOut}");
            Thread.Sleep(4000);

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
