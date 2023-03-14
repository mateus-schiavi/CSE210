using System;

// Class 8: Program - entry point of the application
public class Program
{
    public static void Main(string[] args)
    {
        // Example usage of the DensityCalculator class
        DensityCalculator densityCalculator = new DensityCalculator();
        double density = densityCalculator.Calculate(10.0, 5.0);
        Console.WriteLine($"Density: {density}");

        // Example usage of the PressureCalculator class
        PressureCalculator pressureCalculator = new PressureCalculator();
        double pressure = pressureCalculator.Calculate(20.0, 2.0);
        Console.WriteLine($"Pressure: {pressure}");

        // Example usage of the MolarityCalculator class
        MolarityCalculator molarityCalculator = new MolarityCalculator();
        double molarity = molarityCalculator.Calculate(5.0, 0.5);
        Console.WriteLine($"Molarity: {molarity}");

        // Example usage of the pHCalculator class
        pHCalculator pHCalculator = new pHCalculator();
        double pH = pHCalculator.Calculate(1.0e-7, 0.0);
        Console.WriteLine($"pH: {pH}");
    }
}