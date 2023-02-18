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
            for (int counter = 4; counter >= 0; counter--)
            {
                if (counter == 0)
                {
                    Console.CursorLeft = _breathIn.Length;
                    Console.Write(" ");
                }
                else
                {
                    Console.CursorLeft = _breathOut.Length;
                    Console.Write(counter);
                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine();

            Console.WriteLine($"{_breathOut}");
            for (int counter = 6; counter >= 0; counter--)
            {
                if (counter == 0)
                {
                    Console.CursorLeft = _breathOut.Length;
                    Console.Write(" ");
                }
                else
                {
                    Console.CursorLeft = _breathOut.Length;
                    Console.Write("{0}", counter);
                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("\n");
            UpdateClock();
        }

        FinalNotice();
    }

    private void GetReady()
    {
        Console.WriteLine("Get ready to start breathing...");
        Thread.Sleep(5000);
    }
}
