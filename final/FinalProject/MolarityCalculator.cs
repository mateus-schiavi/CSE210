// Class 6: MolarityCalculator - calculates molarity using the Calculator base class
public class MolarityCalculator : Calculator
{

    public override double Calculate(double moles, double volume)
    {
        return moles / volume;
    }
}