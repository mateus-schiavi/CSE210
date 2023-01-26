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
                myJournal.addAsk();
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
                Console.WriteLine("");
                Console.WriteLine("Then nearly fourteen billion years ago expansion started");
                Console.WriteLine("");
                Console.WriteLine("Wait");
                Console.WriteLine("");
                Console.WriteLine("The Earth began to cool, the autotrophs began to drool");
                Console.WriteLine("");
                Console.WriteLine("Neanderthals developed tools, we built a wall (we built the pyramids)");
                Console.WriteLine("");
                Console.WriteLine("Math, science, history, unraveling the mystery");
                Console.WriteLine("");
                Console.WriteLine("That all started with the Big Bang (bang!)♪");
                Console.WriteLine("");
                Console.WriteLine("Bazinga!");
            }
        }
        
    }
}
    public class dailyJournal{
        List<Ask> myAnswer = new List<Ask>();
        public dailyJournal(){}

        public void addAsk()
        {
            Ask _write = new Ask();
            _write.inputAsk();
            myAnswer.Add(_write);
        }
        public void load(string archive)
        {
            String[] ropes = System.IO.File.ReadAllLines(archive);
            foreach(string key in ropes)
            {
                Ask _word = new Ask();
                _word.loadfile(key);
                myAnswer.Add(_word);
            }
        }
        public void save(string archive)
        {
            using (StreamWriter mywritings = new StreamWriter(archive))
            {
                foreach(Ask _develop in myAnswer)
                {
                    mywritings.WriteLine(_develop.itsString());
                }
            }
        }
        public void display()
        {
            foreach(Ask keyword in myAnswer)
            {
                keyword.displayInput();
            }
        }
        public class Ask
        {
            string _input;
            string[] _questions={"Do you like puzzle?\n", "Do you prefer Marvel or DC?\n", "What would you do if you were the protagonist of your favorite anime?\n", "What do you prefer? Travel around the world or explore new planets?\n","Do you prefer Pokémon or Digimon?\n", "If you were a soccer player, who would you choose as your strike partner? Messi, Cristiano Ronaldo, Neymar ou Benzema?\n","What is your favorite alien from Ben 10?", "Do you prefer Italian Food or Brazilian Food?"};
            public Ask(){}
            public void inputAsk()
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
    