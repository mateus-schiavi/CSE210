// Class 6: MolarityCalculator - calculates molarity using the Calculator base class
public class MolarityCalculator : Calculator
{
    private double moles;
    private double volume;

    public double Moles
    {
        get { return moles; }
        set { moles = value; }
    }

    public double Volume
    {
        get { return volume; }
        set { volume = value; }
    }
 

    public override double Calculate(double moles, double volume)
    {
        Moles = moles;
        Volume = volume;
        return moles / volume;
    }
}