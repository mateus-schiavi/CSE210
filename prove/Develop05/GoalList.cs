using System;

namespace GoalTracker
{
    public class GoalList : Goal
    {
        private string _name;
    private string _description;
    private int _points;
    private bool _completed;
    private int _timesForBonus;
    private int _bonusNumber;
    private int _times = 0;

    public GoalList() : base()
    {
    }

    public override string Display()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with your goal? ");
        _points = Convert.ToInt32(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _timesForBonus = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusNumber = Convert.ToInt32(Console.ReadLine());

        if(_completed == false)
        {
            return $"[] {_name} ({_description}) -- Currently completed: {_times}/{_timesForBonus}";
        }
        else
        {
            return $"[X] {_name} ({_description}) -- Currently completed: {_times}/{_timesForBonus}";
        }
    }
    }
}