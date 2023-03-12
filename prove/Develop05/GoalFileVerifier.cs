using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    class GoalFileVerifier
    {
        private readonly string filePath = "personal_goals.txt";

        public bool VerifyFileIntegrity()
        {
            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"The file '{filePath}' does not exist.");
                    return false;
                }

                // Check if the file is empty
                if (new FileInfo(filePath).Length == 0)
                {
                    Console.WriteLine($"The file '{filePath}' is empty.");
                    return false;
                }

                // Check if the file has the correct header
                string expectedHeader = "Category,Description,Completed,Score";
                string actualHeader = File.ReadLines(filePath).First();
                if (actualHeader != expectedHeader)
                {
                    Console.WriteLine($"The file '{filePath}' has an incorrect header.");
                    return false;
                }

                // Check if each line has the correct format
                List<string> invalidLines = new List<string>();
                foreach (string line in File.ReadLines(filePath).Skip(1))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length != 4 || !bool.TryParse(parts[2], out _) || !int.TryParse(parts[3], out _))
                    {
                        invalidLines.Add(line);
                    }
                }
                if (invalidLines.Count > 0)
                {
                    Console.WriteLine($"The file '{filePath}' has {invalidLines.Count} invalid line(s):");
                    foreach (string line in invalidLines)
                    {
                        Console.WriteLine(line);
                    }
                    return false;
                }

                Console.WriteLine($"The file '{filePath}' is valid.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while verifying the file '{filePath}': {ex.Message}");
                return false;
            }
        }
    }
}