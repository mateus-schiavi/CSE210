// Class 6: MolarityCalculator - calculates molarity using the Calculator base class
public class MolarityCalculator : Calculator
{
    double moles;
    double volume;
    public override double Calculate()
    {
        return moles / volume;
    }
}