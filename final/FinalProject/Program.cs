using System;

// Class 8: Program - entry point of the application
public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of the calculators
        DensityCalculator densityCalculator = new DensityCalculator();
        PressureCalculator pressureCalculator = new PressureCalculator();
        MolarityCalculator molarityCalculator = new MolarityCalculator();
        pHCalculator pHCalculator = new pHCalculator();

        bool quit = false;
        while (!quit)
        {
            // Prompt the user to choose an operation
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Calculate density");
            Console.WriteLine("2. Calculate pressure");
            Console.WriteLine("3. Calculate molarity");
            Console.WriteLine("4. Calculate pH");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            // Perform the chosen operation
            switch (choice)
            {
                case 1:
                    // Calculate density
                    Console.Write("Enter mass in kg: ");
                    double mass = double.Parse(Console.ReadLine());
                    Console.Write("Enter volume in m^3: ");
                    double volume = double.Parse(Console.ReadLine());
                    double density = densityCalculator.Calculate();
                    Console.WriteLine($"Density: {density} kg/m^3");
                    break;
                case 2:
                    // Calculate pressure
                    Console.Write("Enter force in N: ");
                    double force = double.Parse(Console.ReadLine());
                    Console.Write("Enter area in m^2: ");
                    double area = double.Parse(Console.ReadLine());
                    double pressure = pressureCalculator.Calculate();
                    Console.WriteLine($"Pressure: {pressure} Pa");
                    break;
                case 3:
                    // Calculate molarity
                    Console.Write("Enter moles of solute: ");
                    double moles = double.Parse(Console.ReadLine());
                    Console.Write("Enter volume of solution in L: ");
                    double solnVolume = double.Parse(Console.ReadLine());
                    double molarity = molarityCalculator.Calculate();
                    Console.WriteLine($"Molarity: {molarity} mol/L");
                    break;
                case 4:
                    // Calculate pH
                    Console.Write("Enter hydrogen ion concentration in mol/L: ");
                    double hydrogenIonConcentration = double.Parse(Console.ReadLine());
                    double pH = pHCalculator.Calculate();
                    Console.WriteLine($"pH: {pH}");
                    break;
                case 5:
                    // Quit
                    string message = "Thanks for using Physics & Chemistry Calculator! Have a nice week";
                    foreach(char c in message)
                    {
                        Console.Write(c);
                        Thread.Sleep(100);
                    }
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            // Display the menu again if the user didn't choose to quit
            if (!quit)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
