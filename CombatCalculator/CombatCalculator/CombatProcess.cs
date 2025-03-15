using CombatCalculator.Lib;

namespace CombatCalculator
{
    /// <summary>
    /// Represents a binomial distribution of trials and successes.
    /// </summary>
    public class CombatProcess(int numberOfHitDice, int attackerHitSkill)
    {
        #region Properties

        /// <summary>
        /// The number of trials included in the distribution.
        /// </summary>
        public int NumberOfHitDice = numberOfHitDice;

        /// <summary>
        /// The ballistic/weapon skill threshold value of the attacker.
        /// Example: If the attacker hits on a 3+, then this value will be 3.
        /// </summary>
        public int AttackerHitSkill = attackerHitSkill;

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public double GetAttackerHitProbability()
        {
            return Statistics.ProbabilityOfSuccess(6, 6 - (AttackerHitSkill - 1));
        }

        /// <summary>
        /// Returns a binomial distribution of attack roll results based on the process data.
        /// </summary>
        /// <returns>A BinomialDistribution object containing the </int></returns>
        public ProbabilityDistribution GetAttackerHitBinomialDistribution()
        {
            return Statistics.BinomialDistribution(NumberOfHitDice, GetAttackerHitProbability());
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the attacker's hit roll.
        /// </summary>
        /// <returns></returns>
        public ProbabilityDistribution GetAttackerHitUpperCumulativeDistribution()
        {
            return Statistics.UpperCumulativeDistribution(NumberOfHitDice, GetAttackerHitProbability());
        }

        #endregion
    }
}
