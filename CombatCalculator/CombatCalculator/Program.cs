﻿using CombatCalculator.Data;
using CombatCalculator.Lib;

namespace CombatCalculator
{

    /// <summary>
    /// Combat calculator class.
    /// </summary>
    public class CombatCalculator
    {
        #region Private Methods

        /// <summary>
        /// Retrieves the number of dice to roll from the user.
        /// </summary>
        /// <returns>The number of dice to roll.</returns>
        private static int GetIntegerFromUser()
        {
            if (!int.TryParse(Console.ReadLine(), out int userInt) || userInt < 1)
            {
                Console.WriteLine($"Invalid value, defaulting to 1.");
                userInt = 1;
            }

            return userInt;
        }

        /// <summary>
        /// Retrieves the success threshold value from the user.
        /// </summary>
        /// <returns>The success threshold.</returns>
        private static int GetDieSuccessThresholdFromUser()
        {
            if (!int.TryParse(Console.ReadLine(), out int successThreshold) || successThreshold < 1 || successThreshold > 6)
            {
                Console.WriteLine($"Invalid success value, defaulting to 3.");
                successThreshold = 3;
            }

            return successThreshold;
        }

        /// <summary>
        /// Simulates rolling the hit roll of an attack.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="hitStat"></param>
        private static void ProjectHitRoll(AttackerDTO attacker)
        {
            Console.WriteLine($"Attacker is rolling {attacker.NumberOfAttacks} hits, succeeding on a roll of {attacker.HitSkill}+ ...");

            // Get the probability of success with any one hit roll.
            Console.WriteLine($"Probability of any one hit succeeding: {CombatMath.GetHitProbability(attacker) * 100:F2}%");
            Console.WriteLine("");

            // Determine the upper cumulative distribution of successful hits
            Console.WriteLine($"Upper cumulative distribution of hits:");
            var hitRollsUpperCumulativeDistribution = CombatMath.GetHitUpperCumulativeDistribution(attacker);

            // Print the distribution and stats
            Console.WriteLine(hitRollsUpperCumulativeDistribution);
            Console.WriteLine($"Mean: {CombatMath.GetMeanHitRolls(attacker):F2}");
            Console.WriteLine($"Standard deviation: {CombatMath.GetStandardDeviationHitRolls(attacker):F2}");
            Console.WriteLine("");
        }

        /// <summary>
        /// Simulates rolling the wound roll of an attack.
        /// </summary>
        /// <param name="attacker"></param>
        private static void ProjectWoundRoll(AttackerDTO attacker)
        {
            Console.WriteLine($"Projecting wound roll for an attack with {attacker.NumberOfAttacks} hits, a hit skill of {attacker.HitSkill}+, and a successful wound roll being 4+");

            // Get the probability of success with any one wound roll.
            Console.WriteLine($"Probability of any one wound succeeding: {0.5 * 100:F2}%");
            Console.WriteLine("");

            // Determine the upper cumulative distribution of successful wounds
            Console.WriteLine($"Upper cumulative distribution of wounds:");
            var woundRollsUpperCumulativeDistribution = CombatMath.GetWoundUpperCumulativeDistribution(attacker);

            // Print the distribution and stats
            Console.WriteLine(woundRollsUpperCumulativeDistribution);
            Console.WriteLine($"Mean: {CombatMath.GetMeanWoundRolls(attacker):F2}");
            Console.WriteLine($"Standard deviation: {CombatMath.GetStandardDeviationWoundRolls(attacker):F2}");
            Console.WriteLine("");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Main method performs combat calculation and outputs percent liklihood of success.
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                // Get data from user
                Console.WriteLine("Enter number of attacking models (default 1):");
                var numberOfAttackingModels = GetIntegerFromUser();
                Console.WriteLine($"Attacking with {numberOfAttackingModels} models.\n");

                Console.WriteLine("Enter attacker's weapon Attacks stat:");
                var weaponAttacksStat = GetIntegerFromUser();
                Console.WriteLine($"Attacks stat: {weaponAttacksStat}.");

                var totalNumberOfAttacks = numberOfAttackingModels * weaponAttacksStat;
                Console.WriteLine($"Attacker is rolling {totalNumberOfAttacks} hit dice.\n");

                Console.WriteLine("Enter attacker's Weapon/Ballistic Skill (1-6):");
                var attackerHitSkill = GetDieSuccessThresholdFromUser();
                Console.WriteLine($"Attacker hits on {attackerHitSkill}s.\n");

                // Create attacker object
                var attacker = new AttackerDTO
                {
                    NumberOfAttacks = totalNumberOfAttacks,
                    HitSkill = attackerHitSkill
                };

                // Perform hit roll
                ProjectHitRoll(attacker);

                // Perform wound roll
                ProjectWoundRoll(attacker);
            }
        }

        #endregion
    }
}