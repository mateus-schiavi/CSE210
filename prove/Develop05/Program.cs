using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Goal Tracker app!");

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
                        PersonalGoal newGoal = new PersonalGoal();
                        newGoal.AddGoal();
                        newGoal.SaveToFile();
                        break;
                    case "2":
                        PersonalGoal goalToDelete = new PersonalGoal();
                        goalToDelete.DeleteGoal();
                        goalToDelete.SaveToFile();
                        break;
                    case "3":
                        PersonalGoal viewGoals = new PersonalGoal();
                        viewGoals.ViewAllGoals();
                        break;
                    case "4":
                        PersonalGoal SaveGoals = new PersonalGoal();
                        SaveGoals.SaveToFile();
                        break;
                    case "5":
                        PersonalGoal loadFile = new PersonalGoal();
                        loadFile.LoadFromFile();
                        break;
                    case "6":
                        PersonalGoal recordEvent = new PersonalGoal();
                        recordEvent.RecordEvent();
                        break;
                    case "7":
                        PersonalGoal quit = new PersonalGoal();
                        quit.Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
        }
    }

}