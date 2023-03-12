using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Goal Tracker app!");

            Personal goalTracker = new Personal();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a personal goal");
                Console.WriteLine("2. Delete a personal goal");
                Console.WriteLine("3. View all personal goals");
                Console.WriteLine("4. Save to a File");
                Console.WriteLine("5. Load from File ");
                Console.WriteLine("6. Record an event for a personal goal");
                Console.WriteLine("7. Exit");
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        goalTracker.AddGoal();
                        break;
                    case "2":
                        goalTracker.DeleteGoal();
                        break;
                    case "3":
                        goalTracker.ViewAllGoals();
                        break;
                    case "4":
                        goalTracker.SaveToFile();
                        break;
                    case "5":
                        goalTracker.LoadFromFile();
                        break;
                    case "6":
                        goalTracker.RecordEvent();
                        break;
                    case "7":
                        goalTracker.Quit();
                        return;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
        }
    }
}
