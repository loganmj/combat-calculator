using CombatCalculator.Lib;
using System.Text;

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
        /// Returns a binomial distribution of results based on the process data.
        /// </summary>
        /// <returns></returns>
        public BinomialDistribution GetAttackerHitDistribution() 
        {
            return Statistics.BinomialDistribution(NumberOfHitDice, GetAttackerHitProbability());
        }

        /// <summary>
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public double GetAttackerHitProbability()
        {
            return Statistics.ProbabilityOfSuccess(6, 6 - (AttackerHitSkill - 1));
        }

        /// <summary>
        /// Gets the average results of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitMean() 
        {
            return Statistics.BinomialMean(NumberOfHitDice, GetAttackerHitProbability());
        }

        /// <summary>
        /// Gets the standard deviation of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitStandardDeviation() 
        {
            var probabilityOfSingleSuccess = GetAttackerHitProbability();
            return Math.Sqrt(NumberOfHitDice * probabilityOfSingleSuccess * (1 - probabilityOfSingleSuccess));
        }

        /// <summary>
        /// Gets the most common result of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitMode() 
        {
            return Math.Floor((NumberOfHitDice + 1) * GetAttackerHitProbability());
        }

        #endregion
    }
}
