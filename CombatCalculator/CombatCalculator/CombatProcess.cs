using CombatCalculator.Lib;
using System.Text;

namespace CombatCalculator
{
    /// <summary>
    /// Represents a binomial distribution of trials and successes.
    /// </summary>
    public class CombatProcess(int numberOfTrials, int attackerSkill)
    {
        #region Properties

        /// <summary>
        /// The number of trials included in the distribution.
        /// </summary>
        public int NumberOfTrials = numberOfTrials;

        /// <summary>
        /// The ballistic/weapon skill threshold value of the attacker.
        /// Example: If the attacker hits on a 3+, then this value will be 3.
        /// </summary>
        public int AttackerSkill = attackerSkill;

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a binomial distribution of results based on the process data.
        /// </summary>
        /// <returns></returns>
        public BinomialDistribution GetAttackerHitDistribution() 
        {
            return Statistics.BinomialDistribution(NumberOfTrials, GetAttackerHitProbability());
        }

        /// <summary>
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public double GetAttackerHitProbability()
        {
            // return (6 - (AttackerSkill - 1)) / 6.0;
            return Statistics.ProbabilityOfSuccess(6, 6 - (AttackerSkill - 1));
        }

        /// <summary>
        /// Gets the average results of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitMean() 
        {
            return Statistics.BinomialMean(NumberOfTrials, GetAttackerHitProbability());
        }

        /// <summary>
        /// Gets the standard deviation of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitStandardDeviation() 
        {
            var probabilityOfSingleSuccess = GetAttackerHitProbability();
            return Math.Sqrt(NumberOfTrials * probabilityOfSingleSuccess * (1 - probabilityOfSingleSuccess));
        }

        /// <summary>
        /// Gets the most common result of the process.
        /// </summary>
        /// <returns></returns>
        public double GetAttackerHitMode() 
        {
            return Math.Floor((NumberOfTrials + 1) * GetAttackerHitProbability());
        }

        #endregion
    }
}
