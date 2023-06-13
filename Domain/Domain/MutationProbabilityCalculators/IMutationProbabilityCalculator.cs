namespace Domain.MutationProbabilityCalculators;

public interface IMutationProbabilityCalculator
{
    public Fraction GetProbabilityFromSpaceFraction(Fraction spaceFraction);
}