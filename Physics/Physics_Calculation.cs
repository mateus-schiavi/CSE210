using System;

namespace PhysicsCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialVelocity = 10.0; // m/s
            double acceleration = 9.8; // m/s^2
            double time = 5.0; // s

            double finalVelocity = initialVelocity + acceleration * time;

            Console.WriteLine("The final velocity is: " + finalVelocity + " m/s");
        }
    }
}
