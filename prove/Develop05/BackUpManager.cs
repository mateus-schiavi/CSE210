using System;
using System.IO;
 
namespace GoalTracker
{
    class BackupManager
    {
        private string _filePath;
        private string _backupFolderPath;

        public BackupManager(string filePath, string backupFolderPath)
        {
            _filePath = filePath;
            _backupFolderPath = backupFolderPath;
        }

        public void CreateBackup()
        {
            try
            {
                // Create a backup file name
                string fileName = $"personal_goals_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                // Combine the backup folder path and file name
                string backupFilePath = Path.Combine(_backupFolderPath, fileName);

                // Copy the file to the backup location
                File.Copy(_filePath, backupFilePath);

                Console.WriteLine($"Backup created successfully at {backupFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating backup: {ex.Message}");
            }
        }
    }
}
