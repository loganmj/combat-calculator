using CombatCalculator.Data;

namespace CombatCalculator.Lib
{
    /// <summary>
    /// Represents a binomial distribution of trials and successes.
    /// </summary>
    public static class CombatMath
    {
        #region Private Methods

        /// <summary>
        /// Returns the success threshold for succeeding a hit roll.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private static int GetNumberOfSuccessfulResults(int successThreshold)
        {
            return 6 - (successThreshold - 1);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the total number of attack rolls the attacker is making.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static int GetNumberOfAttacks(AttackerDTO attacker)
        {
            return attacker.NumberOfModels * attacker.WeaponAttacks;
        }

        /// <summary>
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public static double GetHitProbability(AttackerDTO attacker)
        {
            return Statistics.ProbabilityOfSuccess(6, GetNumberOfSuccessfulResults(attacker.HitSkill));
        }

        /// <summary>
        /// Returns the success threshold for wounding the defender.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static int GetWoundSuccessThreshold(AttackerDTO attacker, DefenderDTO defender)
        {
            var strength = attacker.WeaponStrength;
            var toughness = defender.Toughness;

            // The attacker's weapon Strength is greater than or equal to double the defender's Toughness.
            if (strength >= 2 * toughness)
            {
                return 2;
            }

            // The attacker's weapon Strength is greater than, but less than double, the defender's Toughness.
            else if (strength > toughness)
            {
                return 3;
            }

            // The attacker's weapon Strength is equal to the defender's Toughness.
            else if (strength == toughness)
            {
                return 4;
            }

            // The attacker's weapon Strength is less than, but more than half, the defender's Toughness.
            else if (strength > toughness / 2)
            {
                return 5;
            }

            // The attacker's weapon Strength is less than or equal to half the defender's Toughness.
            else
            {
                return 6;
            }
        }

        /// <summary>
        /// Returns the probability of succeeding in both a hit and a wound roll for any one attack.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetWoundProbability(AttackerDTO attacker, DefenderDTO defender) 
        {
            return GetHitProbability(attacker) * Statistics.ProbabilityOfSuccess(6, GetNumberOfSuccessfulResults(GetWoundSuccessThreshold(attacker, defender)));
        }

        /// <summary>
        /// Returns a binomial distribution of attack roll results based on the process data.
        /// </summary>
        /// <returns>A BinomialDistribution object containing the hit success data.</returns>
        public static ProbabilityDistribution GetHitBinomialDistribution(AttackerDTO attacker)
        {
            return Statistics.BinomialDistribution(GetNumberOfAttacks(attacker), GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the mean of the attacker's hit roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static double GetMeanHitRolls(AttackerDTO attacker)
        {
            return Statistics.GetMean(GetNumberOfAttacks(attacker), GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the standard deviation of the attacker's hit roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public static double GetStandardDeviationHitRolls(AttackerDTO attacker)
        {
            return Statistics.GetStandardDeviation(GetNumberOfAttacks(attacker), GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the attacker's hit roll.
        /// </summary>
        /// <returns></returns>
        public static ProbabilityDistribution GetHitUpperCumulativeDistribution(AttackerDTO attacker)
        {
            return Statistics.UpperCumulativeDistribution(GetNumberOfAttacks(attacker), GetHitProbability(attacker));
        }

        /// <summary>
        /// Returns a binomial distribution of wound roll results based on the process data.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static ProbabilityDistribution GetWoundBinomialDistribution(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.BinomialDistribution(GetNumberOfAttacks(attacker), GetWoundProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the mean of the attacker's wound roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetMeanWoundRolls(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.GetMean(GetNumberOfAttacks(attacker), GetWoundProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the standard deviation of the attacker's wound roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetStandardDeviationWoundRolls(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.GetStandardDeviation(GetNumberOfAttacks(attacker), GetWoundProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the attacker's wound roll.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static ProbabilityDistribution GetWoundUpperCumulativeDistribution(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.UpperCumulativeDistribution(GetNumberOfAttacks(attacker), GetWoundProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the probability of the attacker passing their hit and wound roll, and the defender failing their save, for any one attack.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetFailedSaveProbability(AttackerDTO attacker, DefenderDTO defender)
        {
            return GetWoundProbability(attacker, defender) * (1 - Statistics.ProbabilityOfSuccess(6, GetNumberOfSuccessfulResults(defender.ArmorSave)));
        }

        /// <summary>
        /// Returns a binomial distribution of rolls where the hit and wound have succeeded, and the opponent failed their save.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static ProbabilityDistribution GetFailSaveBinomialDistribution(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.BinomialDistribution(GetNumberOfAttacks(attacker), GetFailedSaveProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the mean of the failed save roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetMeanFailedSaveRolls(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.GetMean(GetNumberOfAttacks(attacker), GetFailedSaveProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the standard deviation of the failed save roll distribution.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetStandardDeviationFailedSaveRolls(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.GetStandardDeviation(GetNumberOfAttacks(attacker), GetFailedSaveProbability(attacker, defender));
        }

        /// <summary>
        /// Returns the upper cumulative distribution of the failed save roll.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static ProbabilityDistribution GetFailedSaveUpperCumulativeDistribution(AttackerDTO attacker, DefenderDTO defender)
        {
            return Statistics.UpperCumulativeDistribution(GetNumberOfAttacks(attacker), GetFailedSaveProbability(attacker, defender));
        }


        #endregion
    }
}
