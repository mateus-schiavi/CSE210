class Memorizing
{
    public Scripture Scripture { get; set; }

    public void Begin()
    {
        Console.WriteLine("Memorizing: " + Scripture.Reference);

        // Get the number of verses in the scripture
        int numVerses = Scripture.Words.GetLength(0);

        // Loop through each verse and display it with an animation
        for (int i = 0; i < numVerses; i++)
        {
            string verseText = "";
            for (int j = 0; j < Scripture.Words.GetLength(1); j++)
            {
                verseText += Scripture.Words[i, j] + " ";
            }
            DisplayVerseWithAnimation(verseText);
            Console.WriteLine();
        }

        Console.WriteLine("You have successfully memorized this scripture!");
    }

    private void DisplayVerseWithAnimation(string verseText)
    {
        // Loop through each character in the verse and display it with a delay
        for (int i = 0; i < verseText.Length; i++)
        {
            Console.Write(verseText[i]);
            Thread.Sleep(200);
        }
    }
}
