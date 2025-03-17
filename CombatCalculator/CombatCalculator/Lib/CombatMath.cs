using CombatCalculator.Data;

namespace CombatCalculator.Lib
{
    /// <summary>
    /// Represents a binomial distribution of trials and successes.
    /// </summary>
    public static class CombatMath
    {
        #region Public Methods

        /// <summary>
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public static double GetAttackerHitProbability(int attackerHitSkill)
        {
            return Statistics.ProbabilityOfSuccess(6, 6 - (attackerHitSkill - 1));
        }

        /// <summary>
        /// Returns a binomial distribution of attack roll results based on the process data.
        /// </summary>
        /// <returns>A BinomialDistribution object containing the </int></returns>
        public static ProbabilityDistribution GetAttackerHitBinomialDistribution(int numberOfAttacks, int attackerHitSkill)
        {
            return Statistics.BinomialDistribution(numberOfAttacks, GetAttackerHitProbability(attackerHitSkill));
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the attacker's hit roll.
        /// </summary>
        /// <returns></returns>
        public static ProbabilityDistribution GetAttackerHitUpperCumulativeDistribution(int numberOfAttacks, int attackerHitSkill)
        {
            return Statistics.UpperCumulativeDistribution(numberOfAttacks, GetAttackerHitProbability(attackerHitSkill));
        }

        #endregion
    }
}
