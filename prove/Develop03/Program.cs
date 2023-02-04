using System;

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
    public void Begin()
    {
        Console.WriteLine("Starting memorization process...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scripture[] scripts = new Scripture[]
        {
            new Scripture("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.", "John 3:16"),
            new Scripture("Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.", "Proverbs 3:5-6"),
            new Scripture("Do not be afraid, for I am with you; I will bring your children from the east and gather you from the west.", "Isaiah 43:5"),
            new Scripture("Genesis 1:1-2", "In the beginning God created the heaven and earth. And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters."),
            new Scripture("Job 1:1", "There was a man in the land of Uz, whose name was Job; and that man was perfect and upright, and one that feared God, and eschewed evil."),
            new Scripture("Isaiah 8:13", "Sanctify the Lord of hosts himself; and let him be your fear, and let him be your dread"),
            new Scripture("Ecclesiastes 3:1", "To every thing there is as season, and a time to every purpose under the heaven"),
            new Scripture("Psalms 1:5", "For the Lord knoweth the way of the righteous; but the way of the ungodly shall perish"),
            new Scripture("Matthew 5:8","Blessed are the pure in heart: for the shall see God"),
            new Scripture("John 1:1", "In the beginning was the Word, and the Word was with God, and the Word was God"),
            new Scripture("Luke 11:3", "Give us day by day our daily bread"),
            new Scripture("Philemon 1:4-5", "I thank my God, making mention of thee always in my prayers, Hearing of thy love and faith, wich thou hast toward the Lord Jesus, and toward all saints;"),
            new Scripture("Ephesians 2:14","For he is our peace, who hath made both one, and hath broken down the middle wall of partition between us;"),
            new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the thing which the Lor hath commanded, for I know that the Lord giveth no commandments unto the childen of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them"),
            new Scripture("Moroni 2:3", "Now Christ spake these words unto them at the time of his first appearing; and the multitude heard in not, but the disciples heard it; and on as many as the laid their hands, fell the Holy Ghost"),
            new Scripture("Jacob 4:4","For, for this intent have we written these things, that they may know that we knew of Christ, and we had a hope of his glory many hundred years before his coming; and not only ourselves had a hope of his glory, but also all the holy prophets which were before us"),
            new Scripture("Mosiah 3:4","For the Lord hath heard thy prayers, and hath judged of thy righteousness, and hath sent me to declare unto thee that thou mayest rejoice; and that thou mayest declare unto thy people, that they may also be fille with joy."),
            new Scripture("Ether 13:4","Behold, Ether saw the days of Christ, and he spake concerning a New Jerusalem upon this land"), 
            new Scripture("Doctrines and Covenants 82:10","I, the Lord, am bound whe ye do what I say; but when ye do not waht I say, ye have no promise;")
        };

        Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine("Down below there is a list with some Scripture:");
        Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");

        for (int x = 0; x < scripts.Length; x++)
        {
            Console.WriteLine($"{x + 1}. {scripts[x].Quotation}");
        }

        Console.WriteLine("►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄►◄");
        Console.WriteLine("Choose a scripture to learn: ");
        int intChoice = int.Parse(Console.ReadLine());
        Scripture scrSelectedScripture = scripts[intChoice - 1];

        Memorizing objMemorize = new Memorizing();

        objMemorize.Begin();
    }
}
