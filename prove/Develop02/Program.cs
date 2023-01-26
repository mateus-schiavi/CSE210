using System;

class Program
{
    static void Main(string[] args)
    {
        dailyJournal myJournal = new dailyJournal();
        string archive;
        int card = 0;
        //condition which will verify the input number to the range
        while(card!=6){
            Console.WriteLine("1 - Write");
            Console.WriteLine("2 - Display");
            Console.WriteLine("3 - Load");
            Console.WriteLine("4 - Save");
            Console.WriteLine("5 - Music");
            Console.WriteLine("6 - Quit");
            //Converts the string representation of a number to its 32-bit signed integer equivalent.
            card = int.Parse(Console.ReadLine());
            //Add a question
            if(card==1)
            {
                myJournal.addJournalHelper();
            }
            else if(card==2)
            //display the question and the answer
            {
             myJournal.display();   
            }
            //load the file
            else if(card==3)
            {
                Console.WriteLine("Type the file name");
                archive = Console.ReadLine();
                myJournal.load(archive);
            }
            //save the file
            else if(card==4)
            {
                Console.WriteLine("Type the file name");
                archive = Console.ReadLine();
                myJournal.save(archive);
            }
            else if(card==5)
            //write the opening music of the tv series The Big Bang Theory
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
        //List is a collection of objects that maintains the order in which they were added.
        List<JournalHelper> myAnswer = new List<JournalHelper>();
        //constructor method; a constructor method is characterized by having the same name of the class and no types, like: void, string, boolean or datatable
        public dailyJournal(){}
        //creation of a void method, when a method is void, it does not requires a return of a variable
        public void addJournalHelper()
        {
            //when you give a new, you are instantiating a variable.
            JournalHelper _write = new JournalHelper();
            _write.inputJournalHelper();
            myAnswer.Add(_write);
        }
        public void load(string archive)
        {
            //creation of an array of strings
            String[] lines = System.IO.File.ReadAllLines(archive);
            //condition which will verify each key in the array lines
            foreach(string key in lines)
            {
                //load the file, gathered with the informations the user has input
                JournalHelper _word = new JournalHelper();
                _word.loadfile(key);
                myAnswer.Add(_word);
            }
        }
        public void save(string archive)
        {
            //the function using imports a class of functions
            using (StreamWriter mywritings = new StreamWriter(archive))
            {
                //condition which will verify each _develop in myAnswer
                foreach(JournalHelper _develop in myAnswer)
                {
                    mywritings.WriteLine(_develop.itsString());
                }
            }
        }
        public void display()
        {
            //condition which will verify each keyWord in myAnswer
            foreach(JournalHelper keyword in myAnswer)
            {
                //display the answer
                keyword.displayInput();
            }
        }
        public class JournalHelper
        {
            //creation of a string
            string _inlet;
            string[] _questions={"Do you like puzzle?\n", "Do you prefer Marvel or DC?\n", "What would you do if you were the protagonist of your favorite anime?\n", "What do you prefer? Travel around the world or explore new planets?\n","Do you prefer Pokémon or Digimon?\n", "If you were a soccer player, who would you choose as your strike partner? Messi, Cristiano Ronaldo, Neymar ou Benzema?\n","What is your favorite alien from Ben 10?", "Do you prefer Italian Food or Brazilian Food?"};
            //constructor method
            public JournalHelper(){}
            public void inputJournalHelper()
            {
                //creation of a random function, this means that the questions will not come in order
                var measure = new Random();
                //measure the questions, in other words, it will display according to the given options
                _inlet = _questions[measure.Next(1,6)];
                //write the menu
                Console.Write(_inlet);
                //add the function readline to the _inlet string
                _inlet = _inlet+Console.ReadLine();
                //attribute the variable today to the datetime.now function
                DateTime today = DateTime.Now;
                //Converts the value of the current DateTime object to the equivalent short date string representation.
                string main_time = today.ToShortDateString();
                //add the string main_time to the _inlet variable
                _inlet = "("+main_time+")" + _inlet;
            }
            //void method with a overload
            public void loadfile(string input)
            {
                //attributes the _inlet string to the input
                _inlet = input;
            }
            //as it is not a void method, requires a value
            public string itsString()
            {
                //return the value stored in the _inlet variable
                return _inlet;
            }
            public void displayInput()
            {
                //write the value stored in the _inlet variable
                Console.WriteLine(_inlet);
            }
        }
    }
//I will give two examples of types of class in C#:
// public: The type or member can be accessed by any other code in the same assembly or another assembly that references it. The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
// private: The type or member can be accessed only by code in the same class or struct.
// Also, it is important to remember one good thing, when you have a = in a line of code, you are attributing the value to a variable, and when you have a ==, you are makind a comparison between the variable and the value.
//And, to finish, I would like to share a recent experience: I am learning C# with a group of members of my ward and my Stake, but, instead of Visual Studio Code, we are using Visual Studio 2012, and it is being very fun.
//I would like to develop this code with a graphic interface, but i know not if it is possible.    