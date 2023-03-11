using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            PersonalGoal personalGoal = new PersonalGoal();

            while (true)
            {
                Console.WriteLine("Goal Tracker");
                Console.WriteLine("1. Add a personal goal");
                Console.WriteLine("2. Delete a personal goal");
                Console.WriteLine("3. View all personal goals");
                Console.WriteLine("4. Record an event for a personal goal");
                Console.WriteLine("5. Save personal goals to file");
                Console.WriteLine("6. Load personal goals from file");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        personalGoal.AddGoal();
                        break;

                    case 2:
                        personalGoal.DeleteGoal();
                        break;

                    case 3:
                        personalGoal.ViewAllGoals();
                        break;

                    case 4:
                        personalGoal.RecordEvent();
                        break;

                    case 5:
                        personalGoal.SaveToFile();
                        break;

                    case 6:
                        personalGoal.LoadFromFile();
                        break;

                    case 7:
                        personalGoal.Quit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please enter a valid choice!");
                        break;
                }
            }
        }
    }
}
