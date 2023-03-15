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

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (writer.BaseStream.Length == 0)
                {
                    writer.Write("Category,Description,Completed,Score");
                    writer.WriteLine(); // add newline character after header row
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

            Console.Write("Did you complete the goal? (yes/no): ");
            string input = Console.ReadLine();
            bool completed = input.Equals("yes", StringComparison.OrdinalIgnoreCase);

            if (completed)
            {
                Console.Write("Enter the score (0-100): ");
                string scoreInput = Console.ReadLine();
                int score;
                if (!int.TryParse(scoreInput, out score))
                {
                    Console.WriteLine("Invalid score. Please enter a number between 0 and 100.");
                    return;
                }

                goal.Completed = true;
                goal.Score = score;

                Console.Write("Event recorded successfully! Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Event not recorded.");
            }

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
