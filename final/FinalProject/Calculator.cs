// Class 3: Calculator - abstract base class for all calculators
public abstract class Calculator
{
    private double value1;
    private double value2;

    public double Value1
    {
        get { return value1; }
        set { value1 = value; }
    }

    public double Value2
    {
        get { return value2; }
        set { value2 = value; }
    }
    // Abstract method to calculate a property
    public abstract double Calculate(double value1, double value2);
} 