using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Quest Program");
            string userInput;
            string something = "";
            string fileName;
            int points = 0;
            List<string> goalsList = new List<string>();
            goalsList.Add(something);

            do
            {
                Goal goal = new Goal();
                Console.WriteLine("");
                Console.WriteLine($"You have {points} points");
                Console.WriteLine("");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.WriteLine("The types of Goals are: ");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    string typeGoal = Console.ReadLine();
                    if (typeGoal == "1")
                    {
                        TemporaryGoal simple = new TemporaryGoal();
                        goalsList.Add(simple.Display());
                        Console.Clear();
                    }
                    else if (typeGoal == "2")
                    {
                        EverLastingGoal eternal = new EverLastingGoal();
                        goalsList.Add(eternal.Display());
                        Console.Clear();
                    }
                    else if (typeGoal == "3")
                    {
                        GoalList checklist = new GoalList();
                        goalsList.Add(checklist.Display());
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Error! Please, insert the correct number.");
                        Console.Clear();
                    }
                }
                else if (userInput == "2")
                {
                    for (int i = 1; i < goalsList.Count; i++)
                    {
                        Console.WriteLine($"{i}. {goalsList[i]}");
                    }
                }
                else if (userInput == "3")
                {
                    Console.Write("What is the name of the file? ");
                    fileName = Console.ReadLine();
                    if (fileName == "goals.txt")
                    {
                        goal.WriteTextFile(goalsList, fileName);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Wrong file name!");
                        Console.Clear();
                    }
                }
                else if (userInput == "4")
                {
                    Console.Write("What is the name of the file? ");
                    fileName = Console.ReadLine();
                    if (fileName == "goals.txt")
                    {
                        goal.ReadTextFile(goalsList, fileName);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Wrong file name!");
                        Console.Clear();
                    }
                }
                else if (userInput == "5")
                {
                }
            } while (userInput != "6");
        }
    }
}