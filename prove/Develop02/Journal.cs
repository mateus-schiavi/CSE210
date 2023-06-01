using System;
using System.Collections.Generic;

namespace Develop02
{ 
    class Journal
    {
        public List<Entry> Input { get; set; }

        public Journal()
        {
            Input = new List<Entry>();
        }

        public void AddEntry(string strPrompt, string strRespond, DateTime Dtdate_time)
        {
            Entry enType = new Entry(strPrompt, strRespond, Dtdate_time);
            Input.Add(enType);
        }

        
        public void DisplayInput()
        {
            foreach (Entry answer in Input)
            {
                answer.Display();
                Console.WriteLine();
            }
        }
    }
}