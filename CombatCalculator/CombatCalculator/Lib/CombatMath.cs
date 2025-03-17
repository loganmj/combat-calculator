﻿using CombatCalculator.Data;

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
            // return defender.Toughness <= attacker.WeaponStrength ? 2 : (defender.Toughness - attacker.WeaponStrength + 1);
            var successQuotient = attacker.WeaponStrength / (double)defender.Toughness;

            // If the attacker's strength is at least double the defender's toughness, the success threshold is 2+
            if (successQuotient >= 2)
            {
                return 2;
            }

            // If the attacker's strength is between 1 and 2 times the defender's toughness, the success threshold is 3+
            else if (successQuotient <2 && successQuotient > 1)
            {
                return 3;
            }


            // If the attacker's strength is equal to the defender's toughness, the success threshold is 4+
            else if (successQuotient == 1)
            {
                return 4;
            }

            // if the attacker's strength is less than the defender's toughness, but more than half, the success threshold is 5+
            else if (successQuotient < 1 && successQuotient >= 0.5)
            {
                return 5;
            }

            // If the attacker's strength is half or less than the defender's toughness, the success threshold is 6+
            else
            {
                return 6;
            }
        }

        /// <summary>
        /// Returns the probability of wounding the defender with a single attack.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public static double GetWoundProbability(AttackerDTO attacker, DefenderDTO defender) 
        {
            return Statistics.ProbabilityOfSuccess(6, GetNumberOfSuccessfulResults(GetWoundSuccessThreshold(attacker, defender)));
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

        #endregion
    }
}
