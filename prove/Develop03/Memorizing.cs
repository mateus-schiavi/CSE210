using System;

class Memorizing
{
    private Scripture _scripture;

    public Scripture Scripture
    {
        get { return _scripture; }
        set { _scripture = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    public void Begin()
    {
        if (_scripture == null)
        {
            throw new InvalidOperationException("Scripture is not set.");
        }

        Console.WriteLine($"Memorize the following scripture:\n{Scripture.Reference}\n");

        string[,] words = Scripture.Words;
        string scriptureText = "";

        for (int i = 0; i < words.GetLength(0); i++)
        {
            for (int j = 0; j < words.GetLength(1); j++)
            {
                scriptureText += words[i, j] + " ";
            }
        }

        foreach (char letter in scriptureText)
        {
            Console.Write(letter);
            System.Threading.Thread.Sleep(100); // pause for 100 milliseconds
        }

        Console.WriteLine("\n\nYou have finished memorizing the scripture!");
    }
}
