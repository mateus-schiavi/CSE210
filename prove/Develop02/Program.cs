using System;

class Program
{
    static void Main(string[] args)
    {
        dailyJournal myJournal = new dailyJournal();
        string archive;
        int card = 0;

        while(card!=6){
            Console.WriteLine("1 - Write");
            Console.WriteLine("2 - Display");
            Console.WriteLine("3 - Load");
            Console.WriteLine("4 - Save");
            Console.WriteLine("5 - Music");
            Console.WriteLine("6 - Quit");
            card = int.Parse(Console.ReadLine());
            if(card==1)
            {
                myJournal.addEntry();
            }
            else if(card==2)
            {
             myJournal.display();   
            }
            else if(card==3)
            {
                Console.WriteLine("Type the file name");
                archive = Console.ReadLine();
                myJournal.load(archive);
            }
            else if(card==4)
            {
                Console.WriteLine("Type the file name");
                archive = Console.ReadLine();
                myJournal.save(archive);
            }
            else if(card==5)
            {
                Console.WriteLine("♫Our whole universe was in a hot dense state");
                Console.WriteLine("Then nearly fourteen billion years ago expansion started");
                Console.WriteLine("Wait");
                Console.WriteLine("The Earth began to cool, the autotrophs began to drool");
                Console.WriteLine("Neanderthals developed tools, we built a wall (we built the pyramids)");
                Console.WriteLine("Math, science, history, unraveling the mystery");
                Console.WriteLine("That all started with the Big Bang (bang!)♪");
                Console.WriteLine("Bazinga!");
            }
        }
        
    }
}
    public class dailyJournal{
        List<Entry> myAnswer = new List<Entry>();
        public dailyJournal(){}

        public void addEntry()
        {
            Entry _write = new Entry();
            _write.inputEntry();
            myAnswer.Add(_write);
        }
        public void load(string archive)
        {
            String[] ropes = System.IO.File.ReadAllLines(archive);
            foreach(string key in ropes)
            {
                Entry _word = new Entry();
                _word.loadfile(key);
                myAnswer.Add(_word);
            }
        }
        public void save(string archive)
        {
            using (StreamWriter mywritings = new StreamWriter(archive))
            {
                foreach(Entry _develop in myAnswer)
                {
                    mywritings.WriteLine(_develop.itsString());
                }
            }
        }
        public void display()
        {
            foreach(Entry keyword in myAnswer)
            {
                keyword.displayInput();
            }
        }
        public class Entry
        {
            string _input;
            string[] _questions={"What is your favorite color?\n","What is your favorite programming language?\n", "Do you love soccer or any other sport?\n", "What would you do if you were a power ranger?", "What is the best for you? Harry Potter or Lord of the Rings?\n"};
            public Entry(){}
            public void inputEntry()
            {
                var measure = new Random();
                _input = _questions[measure.Next(1,6)];
                Console.Write(_input);
                _input = _input+Console.ReadLine();
                DateTime today = DateTime.Now;
                string main_time = today.ToShortDateString();
                _input = "("+main_time+")" + _input;
            }
            public void loadfile(string input)
            {
                _input = input;
            }
            public string itsString()
            {
                return _input;
            }
            public void displayInput()
            {
                Console.WriteLine(_input);
            }
        }

    }
    