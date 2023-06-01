using System;
 
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        //Default to 1/1
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        if(bottom == 0)
        {
            throw new ArgumentException("The denominator cannot be zero");
        }

        _top = top;
        _bottom = bottom;
        Simplify();
    }

    private void Simplify()
    {
        int gcd = GCD(_top, _bottom);
        _top /= gcd;
        _bottom /= gcd;
    }

    private int GCD(int a, int b)
    {
        while(b !=  0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }

    public string GetFractionString()
    {
        //Notice that this is not stored as a member variable.
        //It is just a temporary, local variable that will be recomputed each time this is called.
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        //Notice that this is not stores as a member variable.
        //It will be recomputed each time this is called.
        return (double)_top / (double)_bottom;
    }

    public Fraction Add(Fraction other)
    {
        int newTop = _top * other._bottom + _bottom * other._top;
        int newBottom = _bottom * other._bottom;

        return new Fraction(newTop, newBottom);
    }

    public Fraction Subtract(Fraction other)
    {
        int newTop = _top * other._bottom - _bottom * other._top;
        int newBottom = _bottom * other._bottom;

        return new Fraction(newTop, newBottom);
    }

    public Fraction Multiply(Fraction other)
    {
        int newTop = _top * other._top;
        int newBottom = _bottom * other._bottom;

        return new Fraction(newTop, newBottom);
    }

    public Fraction Divide(Fraction other)
    {
        int newTop = _top * other._bottom;
        int newBottom = _bottom * other._top;

        return new Fraction(newTop, newBottom);
    }
}