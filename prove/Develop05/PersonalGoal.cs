using System.Collections.Generic;

namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> personalGoals = new List<PersonalGoal>();

        public override void AddGoal()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            PersonalGoal newGoal = new PersonalGoal() { Category = "Personal", Description = description, Completed = false };
            personalGoals.Add(newGoal);
            Console.WriteLine("Personal goal added successfully!");
        }

        public override void DeleteGoal()
        {
            Console.Write("Enter the index of the personal goal you want to delete: ");
            int index = int.Parse(Console.ReadLine());
            personalGoals.RemoveAt(index);
            Console.WriteLine("Personal goal deleted successfully!");
        }

        public override void ViewAllGoals()
        {
            Console.WriteLine("List of all personal goals:");
            for (int i = 0; i < personalGoals.Count; i++)
            {
                Console.WriteLine($"[{i}] Category: {personalGoals[i].Category}, Description: {personalGoals[i].Description}, Completed: {personalGoals[i].Completed}");
            }
        }
    }
}
