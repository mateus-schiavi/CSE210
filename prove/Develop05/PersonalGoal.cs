using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalTracker
{
    class PersonalGoal : Goal
    {
        private List<PersonalGoal> _goals = new List<PersonalGoal>();
        private string filePath = "personal_goals.txt";
        GoalFileVerifier verifier = new GoalFileVerifier("personal_goals.txt");
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

            SaveToFile(); // Save changes to file
        }



        public override void ViewAllGoals()
        {
            verifier.VerifyFileIntegrity();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} not found.");
                return;
            }

            Console.WriteLine("List of all personal goals:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Skip the header row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Skip any blank or invalid lines
                    if (string.IsNullOrWhiteSpace(line) || line.Split(',').Length < 4)
                    {
                        continue;
                    }

                    string[] parts = line.Split(',');
                    string completedMarker = bool.Parse(parts[2]) ? "[O]" : "[X]";
                    Console.WriteLine($"{completedMarker} Category: {parts[0]}, Description: {parts[1]}");
                }
            }
        }


        public override void ListGoals()
        {
            Console.WriteLine("List of all personal goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"[{i}] {_goals[i].Description} {_goals[i].Category}");
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

            // Create the file if it doesn't exist
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("Category,Description,Completed,Score");
                }
            }

            // Update existing goals in the file
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++) // skip header row
            {
                string[] parts = lines[i].Split(',');
                string description = parts[1];

                PersonalGoal goal = _goals.FirstOrDefault(g => g.Description == description);
                if (goal != null)
                {
                    string completed = goal.Completed ? "true" : "false";
                    int score = goal.Completed ? goal.Score : 0;
                    lines[i] = $"{goal.Category},{goal.Description},{completed},{score}";
                }
            }

            // Append new goals to the file
            foreach (PersonalGoal goal in _goals.Where(g => !lines.Any(line => line.Contains(g.Description))))
            {
                string completed = goal.Completed ? "true" : "false";
                int score = goal.Completed ? goal.Score : 0;
                lines.Add($"{goal.Category},{goal.Description},{completed},{score}");
            }

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Goals saved to file successfully!");
        }




        public override void LoadFromFile()
        {
            verifier.VerifyFileIntegrity();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} not found");
                return;
            }

            try
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

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        // Skip any blank or invalid lines
                        if (string.IsNullOrWhiteSpace(line) || line.Split(',').Length < 4)
                        {
                            continue;
                        }

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

            Console.Write("Did you complete the goal? (Y/N): ");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                goal.Completed = true;

                Console.Write("Enter the score for this completion: ");
                int score = int.Parse(Console.ReadLine());
                goal.Score += score;
            }
            else if (input == "n")
            {
                goal.Completed = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                return;
            }
            SaveToFile();

            Console.WriteLine("Event recorded successfully!");
        }





        public override void BackupFile()
        {
            string backupFilePath = $"{Path.GetFileNameWithoutExtension(filePath)}_backup{Path.GetExtension(filePath)}";
            File.Copy(filePath, backupFilePath, true);
            string advice = $"Backup file created successfully at {backupFilePath}";

            foreach (char x in advice)
            {
                Console.Write(x);
                Thread.Sleep(100);
            }
        }


        public override void Quit()
        {
            string message = "Thanks for using Goal Tracker. Have a nice Week";
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
