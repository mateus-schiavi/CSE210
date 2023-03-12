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
    class Personal : Goal
    {
        private List<Personal> Personals = new List<Personal>();
        private string filePath = "personal_goals.txt";
        GoalFileVerifier verifier = new GoalFileVerifier("personal_goals.txt");  

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

                foreach (Personal goal in Personals)
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

            if (File.Exists(filePath))
            {
                Personals.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');
                        Personal goal = new Personal()
                        {
                            Category = parts[0],
                            Description = parts[1],
                            Completed = bool.Parse(parts[2]),
                            Score = int.Parse(parts[3])
                        };
                        Personals.Add(goal);
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

            Personal goal = Personals.FirstOrDefault(goal => goal.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
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

        public override void AddGoal()
        {
            throw new NotImplementedException();
        }

        public override void DeleteGoal()
        {
            throw new NotImplementedException();
        }

        public override void ViewAllGoals()
        {
            throw new NotImplementedException();
        }

        public override void ListGoals()
        {
            throw new NotImplementedException();
        }
    }
}