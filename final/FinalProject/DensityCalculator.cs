// Class 4: DensityCalculator - calculates density using the Calculator base class
public class DensityCalculator : Calculator
{
    double mass;
    double volume;
    public override double Calculate()
    {
        return mass / volume;
    }

}