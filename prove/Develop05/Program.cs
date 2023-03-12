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
            Console.WriteLine("4. List personal goals");
            Console.WriteLine("5. Record an event for a personal goal");
            Console.WriteLine("6. Exit");

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
                    PersonalGoal listGoals = new PersonalGoal();
                    listGoals.ListGoals();
                    break;
                case "5":
                    PersonalGoal recordEvent = new PersonalGoal();
                    recordEvent.RecordEvent();
                    recordEvent.SaveToFile();
                    break;
                case "6":
                    PersonalGoal Quit = new PersonalGoal();
                    Quit.Quit();
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}

}