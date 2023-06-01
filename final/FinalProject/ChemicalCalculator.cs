// Class 2: ChemicalCalculator - calculates chemical properties
public class ChemicalCalculator
{
    // Method to calculate molarity
    public double CalculateMolarity(double moles, double volume)
    {
        return moles / volume;
    }

    // Method to calculate pH
    public double CalculatepH(double hydrogenIonConcentration)
    {
        return -Math.Log10(hydrogenIonConcentration);
    }
} 