namespace Domain.MutationProbabilityCalculators;

public class FullMutationProbabilityCalculator : IMutationProbabilityCalculator
{
    public Fraction GetProbabilityFromSpaceFraction(Fraction spaceFraction) => 1;
}