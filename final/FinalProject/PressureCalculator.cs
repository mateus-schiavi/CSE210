// Class 5: PressureCalculator - calculates pressure using the Calculator base class
public class PressureCalculator : Calculator
{
    public override double Calculate(double force, double area)
    {
        return force / area;
    }
}