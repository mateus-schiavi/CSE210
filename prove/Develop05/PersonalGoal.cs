using System;
using System.Collections.Generic;
using System.IO;
/*When the user types yes, a true statement is shown in the .txt file
And when the user types no, a false statement is shown in the .txt file
*/
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
            foreach (PersonalGoal goal in personalGoals)
            {
                string completedMarker = goal.Completed ? "[O]" : "[X]";
                Console.WriteLine($"{completedMarker} Category: {goal.Category}, Description: {goal.Description}");
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
                    writer.WriteLine($"{goal.Category} | {goal.Description} | {goal.Completed} | {goal.Score}");
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
                        string[] parts = line.Split('|');
                        PersonalGoal goal = new PersonalGoal()
                        {
                            Category = parts[0],
                            Description = parts[1],
                            Completed = bool.Parse(parts[2]),
                            Score = int.Parse(parts[3])
                        };
                        personalGoals.Add(goal);
                    }
                }

                Console.WriteLine("Goals loaded from file successfully!");
                Console.WriteLine("List of all personal goals:");
                foreach (PersonalGoal goal in personalGoals)
                {
                    string completedMarker = goal.Completed ? "[O]" : "[X]";
                    Console.WriteLine($"{completedMarker} Description: {goal.Description}, Score: {goal.Score}");
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

            while (true)
            {
                Console.Write("Have you completed this goal? (yes/no): ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "yes")
                {
                    goal.Completed = true;
                    Console.WriteLine("Congratulations! You have completed a personal goal.");
                    goal.Score = 100;
                    Console.WriteLine("You have earned 100 points!");
                    break;
                }
                else if (answer == "no")
                {
                    Console.WriteLine("Event recorded successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter either 'yes' or 'no'.");
                }
            }

            // Save the score to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (PersonalGoal g in personalGoals)
                {
                    writer.WriteLine($"{g.Category} | {g.Description} | {g.Completed} | {g.Score}");
                }
            }
        }

        public override void Quit()
        {
            Console.WriteLine("Exiting program...");
            Environment.Exit(0);
        }
    }
}