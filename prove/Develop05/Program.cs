using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Goal personalGoal = new PersonalGoal();
            Goal professionalGoal = new ProfessionalGoal();

            while (true)
            {
                Console.WriteLine("Goal Tracker");
                Console.WriteLine("1. Add a personal goal");
                Console.WriteLine("2. Delete a personal goal");
                Console.WriteLine("3. View all personal goals");
                Console.WriteLine("4. Add a professional goal");
                Console.WriteLine("5. Delete a professional goal");
                Console.WriteLine("6. View all professional goals");
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
                        professionalGoal.AddGoal();
                        break;

                    case 5:
                        professionalGoal.DeleteGoal();
                        break;

                    case 6:
                        professionalGoal.ViewAllGoals();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please enter a valid choice!");
                        break;
                }
            }
        }
    }
}
