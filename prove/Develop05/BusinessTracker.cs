using System;
using System.Collections.Generic;

namespace GoalTracker
{
    public class BusinessTracker : Goal
    {
        private List<string> businessGoals;

        public BusinessTracker()
        {
            businessGoals = new List<string>();
        }

        public override void AddGoal()
        {
            Console.WriteLine("Please enter a new business goal:");
            string goal = Console.ReadLine();
            businessGoals.Add(goal);
            Console.WriteLine("Goal added successfully.");
        }

        public override void DeleteGoal()
        {
            Console.WriteLine("Please enter the index of the goal to delete:");
            int index = int.Parse(Console.ReadLine());
            if (index >= 0 && index < businessGoals.Count)
            {
                businessGoals.RemoveAt(index);
                Console.WriteLine("Goal deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        public override void ViewAllGoals()
        {
            Console.WriteLine("All business goals:");
            for (int i = 0; i < businessGoals.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, businessGoals[i]);
            }
        }

        public override void ListGoals()
        {
            Console.WriteLine("Business goals:");
            foreach (string goal in businessGoals)
            {
                Console.WriteLine("- {0}", goal);
            }
        }

        public override void SaveToFile()
        {
            Console.WriteLine("Saving business goals to file...");
            // Code to save goals to a file goes here
        }

        public override void LoadFromFile()
        {
            Console.WriteLine("Loading business goals from file...");
            // Code to load goals from a file goes here
        }

        public override void RecordEvent()
        {
            Console.WriteLine("Please enter the index of the goal to record an event for:");
            int index = int.Parse(Console.ReadLine());
            if (index >= 0 && index < businessGoals.Count)
            {
                Console.WriteLine("Please enter a description of the event:");
                string description = Console.ReadLine();
                businessGoals[index] += " - " + description;
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        public override void Quit()
        {
            Console.WriteLine("Exiting Business Tracker...");
            Environment.Exit(0);
        }
    }
}
