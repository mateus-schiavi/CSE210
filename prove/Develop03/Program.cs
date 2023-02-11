using System;
/*
Exceeds requirements with the use of try/catch
*/
class Scripture
{
    public string Quotation { get; set; }
    public string Reference { get; set; }

    public Scripture(string quotation, string reference)
    {
        Quotation = quotation;
        Reference = reference;
    }
}

class Memorizing
{
    public void Begin(Scripture scripture)
    {
        Console.WriteLine("Starting memorization process for:");
        Console.WriteLine(scripture.Quotation);
        Console.WriteLine("Reference: " + scripture.Reference);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
            {
                {
            Scripture[] scripts = new Scripture[]
            {
                new Scripture("Isaiah 8:13", "Sanctify the Lord of hosts himself; and let him be your fear, and let him be your dread"),
                new Scripture("Ecclesiastes 3:1", "To every thing there is a season, and a time to every purpose under the heaven"),
                new Scripture("Psalms 1:5", "For the Lord knoweth the way of the righteous; but the way of the ungodly shall perish"),
                new Scripture("Matthew 5:8","Blessed are the pure in heart: for they shall see God"),
                new Scripture("John 1:1", "In the beginning was the Word, and the Word was with God, and the Word was God"),
                new Scripture("Luke 11:3", "Give us day by day our daily bread"),
                new Scripture("Ether 13:4","Behold, Ether saw the days of Christ, and he spake concerning a New Jerusalem upon this land"), 
                new Scripture("Doctrines and Covenants 82:10","I, the Lord, am bound when ye do what I say; but when ye do not what I say, ye have no promise;"),
                new Scripture("Abraham 4:1","And the the Lor said: Let us go down. And they went down at the beginninh, and they, that is the Gods, organized and formed"),
                new Scripture("Joseph Smith - Matthew 1:12","When you, therefore, shall see the abomination of desolation, spoken of by Daniel the prophet, concerning the destruction of Jerusalem, then you shall stand in the holy place; whoso readeth let him understand"),
                new Scripture("Articles of Faith 1:13", "We believe in being honest, true, chaste, benevolent, virtuous, and in doing good to all men; indeed, we may say that we follow the admonition of Paul--We believe all things, we hope all things, we have endured many things, and hope to be able to endure all things. If there is anything virtuous, lovely, or of good report or praiseworthy, we seek after these things"),
                new Scripture("Doctrine & Covenants 1:2","For verily the voice of the Lord is unto all men, and there is none to escape; and there is no eye that shall not see, neither ear that shall not hear, neither heart that shall not be penetrated."),
                new Scripture("Doctrine & Covenants 4:1","Now behold, a marvelous work is about to come forth among the children of men.")              
            };

            Console.WriteLine("Welcome to the Scripture Memorizer Program!");
            Console.WriteLine("Below is a list of some scriptures:");
            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

            for (int i = 0; i < scripts.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scripts[i].Quotation}");
            }

            Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");
            Console.WriteLine("Please choose a scripture to memorize (Enter the number): ");

            int choice = int.Parse(Console.ReadLine());
            Scripture selectedScripture = scripts[choice - 1];

            Memorizing objMemorize = new Memorizing();
            objMemorize.Begin(selectedScripture);

            Console.WriteLine("Would you like to memorize another scripture? (y/n)");
            string repeat = Console.ReadLine();

                while (repeat == "y")
                {
            Console.WriteLine("Please choose another scripture to memorize (Enter the number): ");
            choice = int.Parse(Console.ReadLine());
            selectedScripture = scripts[choice - 1];
            objMemorize.Begin(selectedScripture);
            Console.WriteLine("Would you like to memorize another scripture? (y/n)");
            repeat = Console.ReadLine();

                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("An Error Has Occurred " + ex.Message);
        }
    }
}    
