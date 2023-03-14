// Class 7: pHCalculator - calculates pH using the Calculator base class
public class pHCalculator : Calculator
{
    public override double Calculate(double hydrogenIonConcentration, double unused)
    {
        return -Math.Log10(hydrogenIonConcentration);
    }
}