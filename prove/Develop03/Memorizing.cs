class Memorizing
{
    private static readonly int DelayMilliseconds = 50;

    public Scripture Scripture { get; set; }

    public void Begin()
    {
        Console.WriteLine("Memorizing:");
        Console.WriteLine("--------------");

        string[,] words = Scripture.Words;

        for (int i = 0; i < words.GetLength(1); i++)
        {
            string word = words[0, i];
            for (int j = 0; j < word.Length; j++)
            {
                Console.Write(word[j]);
                Thread.Sleep(DelayMilliseconds);
            }
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
