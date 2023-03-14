// Class 4: DensityCalculator - calculates density using the Calculator base class
public class DensityCalculator : Calculator
{
    public override double Calculate(double mass, double volume)
    {
        return mass / volume;
    }
}