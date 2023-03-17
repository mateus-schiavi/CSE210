using System;

// Class 7: pHCalculator - calculates pH using the Calculator base classpublic class pHCalculator : Calculator
public class pHCalculator : Calculator

{
    double hydrogenIonConcentration;
    public override double Calculate()
    {
        double pH = -Math.Log10(hydrogenIonConcentration);
        double pOH = 14 - pH;
        Console.WriteLine("pH = " + pH);
        Console.WriteLine("pOH = " + pOH);
        return pH;
    }
}
