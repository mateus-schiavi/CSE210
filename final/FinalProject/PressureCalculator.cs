// Class 5: PressureCalculator - calculates pressure using the Calculator base class
public class PressureCalculator : Calculator
{
    double force;
    double area;
    public override double Calculate()
    {
        return force / area;
    }
}