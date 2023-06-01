// Class 4: DensityCalculator - calculates density using the Calculator base class
public class DensityCalculator : Calculator
{
    private double mass;
    private double volume;

    public double Mass
    {
        get { return mass; }
        set { mass = value; }
    }

    public double Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    public override double Calculate(double mass, double volume)
    {
        Mass = mass;
        Volume = volume;
        return mass / volume;
    }
} 