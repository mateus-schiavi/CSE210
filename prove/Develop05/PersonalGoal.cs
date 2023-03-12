using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
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
        private string filePath = "personal_goals.txt";
        GoalFileVerifier verifier = new GoalFileVerifier("personal_goals.txt");
        public override void AddGoal()
        {
            verifier.VerifyFileIntegrity();
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

            personalGoals.Add(newGoal); // Add the new goal to the list
            Console.WriteLine("Personal goal added successfully!");

            SaveToFile(); // Save the changes to the file
        }

        public override void DeleteGoal()
        {
            verifier.VerifyFileIntegrity();
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
            LoadFromFile(); // Load goals from the file

            if (personalGoals.Count == 0)
            {
                Console.WriteLine("No personal goals found.");
                return;
            }

            Console.WriteLine("List of all personal goals:");
            foreach (PersonalGoal goal in personalGoals)
            {
                string completedMarker = goal.Completed ? "[O]" : "[X]";
                int score = goal.Completed ? 100 : goal.Score;
                Console.WriteLine($"{completedMarker} Category: {goal.Category}, Description: {goal.Description}, Score: {goal.Score}");
            }
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

                // Iterate over the personalGoals list by index
                for (int i = 0; i < personalGoals.Count; i++)
                {
                    PersonalGoal goal = personalGoals[i];
                    string completed = goal.Completed ? "true" : "false";
                    writer.WriteLine($"{goal.Category},{goal.Description},{completed},{goal.Score}");
                }

                writer.Flush(); // flush the stream to persist changes
            }

            Console.WriteLine("Goals saved to file successfully!");
        }


        public override void LoadFromFile()
        {
            verifier.VerifyFileIntegrity();
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

            Console.Write($"Did you complete the personal goal '{goal.Description}'? (yes/no) ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                goal.Completed = true;
                Console.WriteLine($"Event recorded successfully for personal goal '{goal.Description}'.");
            }
            else if (answer == "no")
            {
                goal.Completed = false;
                Console.WriteLine($"Event recorded successfully for personal goal '{goal.Description}'.");
            }
            else
            {
                Console.WriteLine("Invalid answer. Please enter 'yes' or 'no'.");
                return;
            }

            SaveToFile(); // Save the changes to the file
        }


        public override void Quit()
        {
            string message = "Thanks for using Goal Tracker! Have a Nice Week";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(110); // Pause for 110 milliseconds
            }
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}