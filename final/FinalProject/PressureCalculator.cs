public class PressureCalculator : Calculator
{
    private double force;
    private double area;

    public double Force
    {
        get { return force; }
        set { force = value; }
    }

    public double Area
    {
        get { return area; }
        set { area = value; }
    }

    public override double Calculate(double force, double area)
    {
        Force = force;
        Area = area;
        return force / area;
    }
} 