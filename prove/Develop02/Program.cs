using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Develop02
{
    class Program
    {

        static Journal Diary = new Journal();
        static string actualDiary;

        static void Main(string[] args)
        {
            
            while (true)
            {

                DisplayMenu();

                int option = GetOption();

                switch (option)
                {
                    case 1:
                        LoadFile();
                        break;
                    case 2:
                        DisplayFile();
                        break;
                    case 3:
                        AddEntry();
                        break;
                    case 4:
                        SaveFile();
                        break;
                    case 5:
                        ShowMusic();
                        break;
                    case 6:
                        Leave();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Journal App");
            Console.WriteLine("Actual File: " + actualDiary);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Load File");
            Console.WriteLine("2. Show file at the terminal");
            Console.WriteLine("3. Add an answer to a question");
            Console.WriteLine("4. Save file as ");
            Console.WriteLine("5. Show Music: ");
            Console.WriteLine("6. Leave the program");
            Console.WriteLine();
        }

        static int GetOption()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter option: ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
            return option;
        }
        static void LoadFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            actualDiary = fileName;

            if (!File.Exists(fileName))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file does not exist.");
                return;
            }

            string json = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file is empty.");
                return;
            }

            Diary = JsonSerializer.Deserialize<Journal>(json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Journal Loaded!");
        }

        static void AddEntry()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string prompt;
            Console.WriteLine("Would you like to choose your own question? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
            prompt = Entry.GetPrompt();
            }
            else
            {
            Random rand = new Random();
            int index = rand.Next(0, Entry.prompts.Count);
            prompt = Entry.prompts[index];
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Prompt: " + prompt);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter response: ");
            string response = Console.ReadLine();
            DateTime date = DateTime.Now;
            Diary.AddEntry(prompt, response, date);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Entry saved to "+ actualDiary);
            JournalHelper.SaveFile(Diary, actualDiary);
        }

        // DisplayJournal() method displays the current journal file to the user.
        // If the current file does not exist or is empty, an error message is displayed.
        // This program exceeds requirments with the use of JSON for storage
        static void DisplayFile()
        {
            string fileName = actualDiary;
            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This file cannot be opened due its nonexistence");
                return;
            }

            string json = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Diary is without content.");
                return;
            }

            Diary = JsonSerializer.Deserialize<Journal>(json);
            Diary.DisplayInput();
        }

        // SaveJournal() method prompts the user to enter a file name and saves the current journal to that file.
        // It then displays a message indicating that the journal has been saved to the specified file.
        static void SaveFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please, type the name of the file you want to save: ");
            string file_Name = Console.ReadLine();
            actualDiary = file_Name;

            string json = JsonSerializer.Serialize(Diary);
            File.WriteAllText(file_Name, json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File saved as " + file_Name);
        }
        
        static void ShowMusic()
        {
            Console.WriteLine("♫♪♪♫");
            Console.WriteLine("Our whole universe was in a hot dense state");
            Console.WriteLine("Then nearly fourteen billion years ago expansion started");
            Console.WriteLine("Wait");
            Console.WriteLine("The Earth began to cool, the autotrophs began to drool");
            Console.WriteLine("Neanderthals developed tools, we built a wall (we built the pyramids)");
            Console.WriteLine("Math, science, history, unraveling the mystery");
            Console.WriteLine("That all started with the Big Bang (bang!)");
            Console.WriteLine("Bazinga!");
            Console.WriteLine("♫♪♪♫");
        }
        static void Leave()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Thanks for your participation!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Environment.Exit(0);
        }
    }
}