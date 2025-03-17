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
        public static double GetHitProbability(AttackerDTO attacker)
        {
            return Statistics.ProbabilityOfSuccess(6, 6 - (attacker.HitSkill - 1));
        }

        /// <summary>
        /// Returns a binomial distribution of attack roll results based on the process data.
        /// </summary>
        /// <returns>A BinomialDistribution object containing the </int></returns>
        public static ProbabilityDistribution GetHitBinomialDistribution(AttackerDTO attacker)
        {
            return Statistics.BinomialDistribution(attacker.NumberOfAttacks, GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the mean of the attacker's hit roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static double GetMeanHitRolls(AttackerDTO attacker)
        {
            return Statistics.GetMean(attacker.NumberOfAttacks, GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the standard deviation of the attacker's hit roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static double GetStandardDeviationHitRolls(AttackerDTO attacker)
        {
            return Statistics.GetStandardDeviation(attacker.NumberOfAttacks, GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the attacker's hit roll.
        /// </summary>
        /// <returns></returns>
        public static ProbabilityDistribution GetHitUpperCumulativeDistribution(AttackerDTO attacker)
        {
            return Statistics.UpperCumulativeDistribution(attacker.NumberOfAttacks, GetHitProbability(attacker));
        }

        public static ProbabilityDistribution GetWoundBinomialDistribution(AttackerDTO attacker) 
        {
            return Statistics.BinomialDistribution(attacker.NumberOfAttacks, GetHitProbability(attacker) * 0.5);
        }

        public static double GetMeanWoundRolls(AttackerDTO attacker)
        {
            return Statistics.GetMean(attacker.NumberOfAttacks, GetHitProbability(attacker) * 0.5);
        }

        public static double GetStandardDeviationWoundRolls(AttackerDTO attacker)
        {
            return Statistics.GetStandardDeviation(attacker.NumberOfAttacks, GetHitProbability(attacker)* 0.5);
        }

        public static ProbabilityDistribution GetWoundUpperCumulativeDistribution(AttackerDTO attacker)
        {
            return Statistics.UpperCumulativeDistribution(attacker.NumberOfAttacks, GetHitProbability(attacker) * 0.5);
        }

        #endregion
    }
}
