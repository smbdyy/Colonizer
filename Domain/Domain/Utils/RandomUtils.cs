using Domain.MutationProbabilityCalculators;

namespace Domain.Utils;

public static class RandomUtils
{
    public static bool GetTrueWithProbability(Fraction probability)
        => Random.Shared.NextDouble() <= probability;
}