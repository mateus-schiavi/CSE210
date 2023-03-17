public abstract class Calculator
{
    private double value1;
    private double value2;

    // Getter for value1
    public double getValue1() {
        return value1;
    }

    // Setter for value1
    public void setValue1(double value1) {
        this.value1 = value1;
    }

    // Getter for value2
    public double getValue2() {
        return value2;
    }

    // Setter for value2
    public void setValue2(double value2) {
        this.value2 = value2;
    }

    // Abstract method to calculate a property
    public abstract double Calculate();
}
