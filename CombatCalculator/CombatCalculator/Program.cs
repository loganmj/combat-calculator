using CombatCalculator.Data;
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
        /// Simulates the rolling of the given number of dice.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="hitStat"></param>
        private static void ProjectHitRoll(AttackerDTO attacker)
        {
            Console.WriteLine($"Attacker is making {attacker.NumberOfAttacks} attacks, succeeding on a roll of {attacker.HitSkill}+ ...");

            // Get the probability of success with one die
            Console.WriteLine($"Probability of any one attack succeeding: {CombatMath.GetAttackerHitProbability(attacker) * 100:F2}%");
            Console.WriteLine("");

            // Determine binomial distribution of success with all dice
            // Print the distribution and stats
            Console.WriteLine($"Binomial distribution for {attacker.NumberOfAttacks} dice rolling {attacker.HitSkill}+:");
            var attackBinomialDistribution = CombatMath.GetAttackerHitBinomialDistribution(attacker);
            Console.WriteLine(attackBinomialDistribution);
            Console.WriteLine($"Mean: {Statistics.GetMean(attackBinomialDistribution):F2}");
            Console.WriteLine($"Standard deviation: {Statistics.GetStandardDeviation(attackBinomialDistribution):F2}");
            Console.WriteLine($"Median: {Statistics.GetMedian(attackBinomialDistribution)}");
            Console.WriteLine($"Mode: {Statistics.GetMode(attackBinomialDistribution)}");
            Console.WriteLine("");

            // Determine the upper cumulative distribution of success
            // Print the distribution and stats
            Console.WriteLine($"Upper cumulative distribution for {attacker.NumberOfAttacks} dice rolling {attacker.HitSkill}+:");
            var attackUpperCumulativeDistribution = CombatMath.GetAttackerHitUpperCumulativeDistribution(attacker);
            Console.WriteLine(attackUpperCumulativeDistribution);
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
            }
        }

        #endregion
    }
}