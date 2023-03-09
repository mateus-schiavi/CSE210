using System;
using System.Collections.Generic;
using System.IO;
/*When the user types yes, a true statement is shown in the .txt file
And when the user types no, a false statement is shown in the .txt file
Also, when the user types complete to a goal, it is shown [O] and [X] when
the user types not complete to a goal
*/
namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> personalGoals = new List<PersonalGoal>();

        private string filePath = "personal_goals.csv";

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

            SaveToFile();
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
            Console.WriteLine("Saving Goals...");

            // Display a spinner while saving the goals
            string[] spinner = { "/", "-", "\\", "|" };
            int spinnerIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"\r{spinner[spinnerIndex]}");
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(100);
            }
            Console.WriteLine();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Category,Description,Completed,Score");
                foreach (PersonalGoal goal in personalGoals)
                {
                    writer.WriteLine($"{goal.Category},{goal.Description},{goal.Completed},{goal.Score}");
                }
            }
            Console.WriteLine("Goals saved to file successfully!");
        }



        public override void LoadFromFile()
        {
            Console.WriteLine("Loading Goals...");

            // Display a spinner while loading the goals
            string[] spinner = { "/", "-", "\\", "|" };
            int spinnerIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"\r{spinner[spinnerIndex]}");
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(100);
            }
            Console.WriteLine();

            if (File.Exists(filePath))
            {
                personalGoals.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');
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

                // Display the loaded goals
                Console.WriteLine("List of all personal goals:");
                foreach (PersonalGoal goal in personalGoals)
                {
                    string completedMarker = goal.Completed ? "[O]" : "[X]";
                    Console.WriteLine($"|{completedMarker}| {goal.Category} | {goal.Description}| {goal.Score}|");
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
            PersonalGoal goal = personalGoals.FirstOrDefault(g => g.Description.Equals(description, StringComparison.OrdinalIgnoreCase));

            if (goal == null)
            {
                Console.WriteLine($"Personal goal with description '{description}' not found.");
                return;
            }

            Console.Write("Did you complete the goal? (yes/no): ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "yes":
                    goal.Completed = true;
                    Console.WriteLine("Personal goal completed successfully!");
                    break;
                case "no":
                    goal.Completed = false;
                    Console.WriteLine("Personal goal not completed.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

            SaveToFile();
        }

        public override void Quit()
        {
            string message = "Good Bye!";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Pause for 50 milliseconds
            }
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}