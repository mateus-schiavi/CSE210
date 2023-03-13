using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> _goals = new List<PersonalGoal>();
        private string filePath = "personal_goals.txt";
        GoalFileVerifier verifier = new GoalFileVerifier("personal_goals");
        public PersonalGoal(string category, string description)
        {
            Category = category;
            Description = description;
            Completed = false;
        }

        public PersonalGoal()
        {
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

            using (StreamWriter writer = new StreamWriter(filePath, true)) // use FileMode.Append to save without replacing
            {
                // Only write the header row if the file is empty
                if (new FileInfo(filePath).Length == 0)
                {
                    writer.WriteLine("Category,Description,Completed,Score");
                }

                foreach (PersonalGoal goal in _goals)
                {
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

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                Environment.Exit(0);
            }

            try
            {
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

                        _goals.Add(goal); // add the loaded goal to the list
                    }
                }

                Console.WriteLine("Goals loaded from file successfully!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
            }
        }




        public override void RecordEvent()
        {
            Console.Write("Enter the description of the personal goal you want to record an event for: ");
            string description = Console.ReadLine();

            PersonalGoal goal = _goals.FirstOrDefault(goal => goal.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (goal == null)
            {
                Console.WriteLine($"Personal goal with description '{description}' not found.");
                return;
            }

            Console.Write("Did you complete the goal? (yes/no): ");
            string input = Console.ReadLine();
            bool completed = input.Equals("yes", StringComparison.OrdinalIgnoreCase);

            if (completed)
            {
                Console.WriteLine("Congratulations, you completed the goal!");
                goal.Completed = true;
                goal.Score += 100;
            }
            else
            {
                Console.WriteLine("Goal not completed.");
            }

            SaveToFile();
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
