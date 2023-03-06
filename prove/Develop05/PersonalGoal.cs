using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> personalGoals = new List<PersonalGoal>();

        private string filePath = "personal_goals.txt";

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
                    newGoal = new PersonalGoal() { Category = "Daily", Description = description, Completed = false };
                    break;
                case 2:
                    newGoal = new PersonalGoal() { Category = "Weekly", Description = description, Completed = false };
                    break;
                case 3:
                    newGoal = new PersonalGoal() { Category = "Monthly", Description = description, Completed = false };
                    break;
                default:
                    Console.WriteLine("Invalid frequency selected.");
                    return;
            }

            personalGoals.Add(newGoal);
            Console.WriteLine("Personal goal added successfully!");
        }


        public override void DeleteGoal()
        {
            Console.Write("Enter the description of the personal goal you want to delete: ");
            string description = Console.ReadLine();

            PersonalGoal goalToDelete = personalGoals.FirstOrDefault(goal => goal.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (goalToDelete == null)
            {
                Console.WriteLine($"Personal goal with description '{description}' not found.");
                return;
            }

            personalGoals.Remove(goalToDelete);
            Console.WriteLine("Personal goal deleted successfully!");
        }




        public override void ViewAllGoals()
        {
            Console.WriteLine("List of all personal goals:");
            for (int i = 0; i < personalGoals.Count; i++)
            {
                string completedMarker = personalGoals[i].Completed ? "[o]" : "[ ]";
                Console.WriteLine($"{completedMarker} [{i}] Category: {personalGoals[i].Category}, Description: {personalGoals[i].Description}");
            }
        }


        public override void CreateNewGoal()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            PersonalGoal newGoal = new PersonalGoal() { Category = "Personal", Description = description, Completed = false };
            personalGoals.Add(newGoal);
            Console.WriteLine("Personal goal added successfully!");
        }

        public override void ListGoals()
        {
            Console.WriteLine("List of all personal goals:");
            for (int i = 0; i < personalGoals.Count; i++)
            {
                Console.WriteLine($"[{i}] {personalGoals[i].Description} ({personalGoals[i].Category})");
            }
        }

        public override void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (PersonalGoal goal in personalGoals)
                {
                    writer.WriteLine($"{goal.Category} | {goal.Description} | {goal.Completed}");
                }
            }
            Console.WriteLine("Goals saved to file successfully!");
        }


        public override void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                personalGoals.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');
                        PersonalGoal goal = new PersonalGoal()
                        {
                            Category = parts[0],
                            Description = parts[1],
                            Completed = bool.Parse(parts[2])
                        };
                        personalGoals.Add(goal);
                    }
                }

                Console.WriteLine("Goals loaded from file successfully!");
                Console.WriteLine("List of all personal goals:");
                for (int i = 0; i < personalGoals.Count; i++)
                {
                    string completedMarker = personalGoals[i].Completed ? "[O]" : "[X]";
                    Console.WriteLine($"{completedMarker} [{i}] Category: {personalGoals[i].Category}, Description: {personalGoals[i].Description}");
                }
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }



        public override void RecordEvent()
        {
            Console.Write("Enter the description of the personal goal you want to record an event for: ");
            string description = Console.ReadLine();

            // Find the first personal goal with a matching description
            PersonalGoal goal = personalGoals.FirstOrDefault(g => g.Description == description);

            if (goal == null)
            {
                Console.WriteLine("No personal goal found with the given description.");
                return;
            }

            Console.Write("Enter the event description: ");
            string eventDescription = Console.ReadLine();
            goal.Events.Add(eventDescription);

            Console.Write("Have you filled this goal? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                goal.Completed = true;
                Console.WriteLine("Congratulations! You have completed a personal goal.");
                Console.WriteLine("You have earned 100 points!");
            }
            else
            {
                Console.WriteLine("Event recorded successfully!");
            }
        }

        public override void Quit()
        {
            Console.WriteLine("Saving goals to file...");
            SaveToFile();
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
    }
}