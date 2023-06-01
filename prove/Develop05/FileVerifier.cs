using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    abstract class FileVerifier
    {
        protected readonly string filePath;

        public FileVerifier(string filePath)
        {
            this.filePath = filePath;
        }

        public abstract bool VerifyFileIntegrity();
    }
} 