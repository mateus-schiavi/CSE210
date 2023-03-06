using System.Collections.Generic;

namespace GoalTracker
{
    class ProfessionalGoal : Goal
    {
        private List<ProfessionalGoal> professionalGoals = new List<ProfessionalGoal>();

        public override void AddGoal()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            ProfessionalGoal newGoal = new ProfessionalGoal() { Category = "Professional", Description = description, Completed = false };
            professionalGoals.Add(newGoal);
            Console.WriteLine("Professional goal added successfully!");
        }

        public override void DeleteGoal()
        {
            Console.Write("Enter the index of the professional goal you want to delete: ");
            int index = int.Parse(Console.ReadLine());
            professionalGoals.RemoveAt(index);
            Console.WriteLine("Professional goal deleted successfully!");
        }

        public override void ViewAllGoals()
        {
            Console.WriteLine("List of all professional goals:");
            for (int i = 0; i < professionalGoals.Count; i++)
            {
                Console.WriteLine($"[{i}] Category: {professionalGoals[i].Category}, Description: {professionalGoals[i].Description}, Completed: {professionalGoals[i].Completed}");
            }
        }
    }
}