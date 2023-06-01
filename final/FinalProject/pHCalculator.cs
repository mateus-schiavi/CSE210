public class pHCalculator : Calculator
{
    private double hydrogenIonConcentration;

    public double HydrogenIonConcentration
    {
        get { return hydrogenIonConcentration; }
        set { hydrogenIonConcentration = value; }
    }

    public override double Calculate(double hydrogenIonConcentration, double unused)
    {
        HydrogenIonConcentration = hydrogenIonConcentration;
        double pH = -Math.Log10(hydrogenIonConcentration);
        double pOH = 14 - pH;
        Console.WriteLine("pH = " + pH);
        Console.WriteLine("pOH = " + pOH);
        return pH;
    }
} 