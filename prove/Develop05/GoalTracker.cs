using System;
using System.Collections.Generic;

namespace GoalTracker
{
    public abstract class Goal
    {
        private string category;
        private string description;
        private bool completed;
        public List<string> Events { get; set; }

        public Goal()
        {
            Events = new List<string>();
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public abstract void AddGoal();

        public abstract void DeleteGoal();

        public abstract void ViewAllGoals();
        public abstract void CreateNewGoal();
        public abstract void ListGoals();
        public abstract void SaveToFile();
        public abstract void LoadFromFile();
        public abstract void RecordEvent();
        public abstract void Quit();
    }
}