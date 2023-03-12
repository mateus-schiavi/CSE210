using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> _goals = new List<PersonalGoal>();

        public PersonalGoal(string category, string description)
        {
            Category = category;
            Description = description;
            Completed = false;
        }

        public override void AddGoal()
        {
            Console.WriteLine("Select goal frequency:");
            Console.WriteLine("1. Daily Goal");
            Console.WriteLine("2. Weekly Goal");
            Console.WriteLine("3. Monthly Goal");
            int frequency = int.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            PersonalGoal newGoal;

            switch (frequency)
            {
                case 1:
                    newGoal = new PersonalGoal("Daily", description);
                    break;
                case 2:
                    newGoal = new PersonalGoal("Weekly", description);
                    break;
                case 3:
                    newGoal = new PersonalGoal("Monthly", description);
                    break;
                default:
                    Console.WriteLine("Invalid frequency selected.");
                    return;
            }

            _goals.Add(newGoal); // Add the new goal to the list
            Console.WriteLine("Personal goal added successfully!");
        }

        public override void DeleteGoal()
        {
            Console.Write("Enter the description of the personal goal you want to delete: ");
            string description = Console.ReadLine();

            PersonalGoal goalToDelete = _goals.FirstOrDefault(goal => goal.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (goalToDelete == null)
            {
                Console.WriteLine($"Personal goal with description '{description}' not found.");
                return;
            }

            _goals.Remove(goalToDelete);
            Console.WriteLine("Personal goal deleted successfully!");
        }

        public override void ViewAllGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No personal goals found.");
                return;
            }

            Console.WriteLine("List of all personal goals:");
            foreach (PersonalGoal goal in _goals)
            {
                string completedMarker = goal.Completed ? "[O]" : "[X]";
                Console.WriteLine($"{completedMarker} Category: {goal.Category}, Description: {goal.Description}");
            }
        }

        public override void ListGoals()
        {
            Console.WriteLine("List of all personal goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"[{i}] {_goals[i].Description} ({_goals[i].Category})");
            }
        }

        public override void SaveToFile()
        {
            throw new NotImplementedException();
        }

        public override void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public override void RecordEvent()
        {
            throw new NotImplementedException();
        }

        public override void Quit()
        {
            throw new NotImplementedException();
        }
    }
}
