using System;

// Class 1: PhysicalCalculator - calculates physical properties
public class PhysicalCalculator
{
    // Method to calculate density
    public double CalculateDensity(double mass, double volume)
    {
        return mass / volume;
    }

    // Method to calculate pressure
    public double CalculatePressure(double force, double area)
    {
        return force / area;
    }
}