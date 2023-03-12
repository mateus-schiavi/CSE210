using System;

namespace GoalTracker
{
    public class TemporaryGoal : Goal
    {
        private string _name;
        private string _description;
        private int _points;
        private bool _completed;

        public TemporaryGoal() : base()
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

            if (_completed == false)
            {
                return $"[] {_name} ({_description})";
            }
            else
            {
                return $"[X] {_name} ({_description})";
            }

        }
    }
}