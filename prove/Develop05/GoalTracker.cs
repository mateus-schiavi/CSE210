using System;

namespace GoalTracker

{
    public class Goal
{
    private string _fileName;
    private List<string> _goals = new List<string>();
    public Goal(){}

    public virtual string Display()
    {
        return "";
    }

    public void WriteTextFile(List<string> goals, string fileName)
    {
        _fileName = fileName;
        _goals = goals;
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            for(int i = 1; i < _goals.Count; i++)
            {
                outputFile.WriteLine($"{i}. {_goals[i]}");
            }
        }
    }

    public void ReadTextFile(List<string> goals, string fileName)
    {
        _fileName = fileName;
        _goals = goals;
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string items = parts[0];
            goals.Add(items);
        }
    }
}
}