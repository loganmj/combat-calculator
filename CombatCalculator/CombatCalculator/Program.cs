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
        private static int GetNumberOfDiceFromUser()
        {
            Console.WriteLine("Enter number of dice to roll:");
            return !int.TryParse(Console.ReadLine(), out int numberOfDice) ? 0 : numberOfDice;
        }

        /// <summary>
        /// Retrieves the success threshold value from the user.
        /// </summary>
        /// <returns>The success threshold.</returns>
        private static int GetSuccessThresholdFromUser() 
        {
            Console.WriteLine("Enter a success threshold from 1 to 6:");
            return !int.TryParse(Console.ReadLine(), out int successThreshold) ? 1 : successThreshold;
        }

        /// <summary>
        /// Simulates the rolling of the given number of dice.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="hitStat"></param>
        private static void ProjectHitRoll(CombatProcess process)
        {
            Console.WriteLine($"Rolling {process.NumberOfHitDice} dice, succeeding on a roll of {process.AttackerHitSkill}+ ...");

            // Get the probability of success with one die
            Console.WriteLine($"Probability of succeeding with one die: {process.GetAttackerHitProbability()}");
            Console.WriteLine("\n");

            // Determine binomial distribution of success with all dice
            // Print the distribution and stats
            Console.WriteLine($"Binomial distribution for {process.NumberOfHitDice} dice rolling {process.AttackerHitSkill}+:");
            Console.WriteLine(process.GetAttackerHitDistribution());
            Console.WriteLine($"Average number of successes: {process.GetAttackerHitMean():F2}");
            Console.WriteLine($"Standard deviation: {process.GetAttackerHitStandardDeviation():F2}");
            Console.WriteLine($"Mode: {process.GetAttackerHitMode():F2}");
            Console.WriteLine("\n");
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
                var numberOfHitDice = GetNumberOfDiceFromUser();
                Console.WriteLine($"Attacker is rolling {numberOfHitDice} hit dice.\n");

                var attackerHitValue = GetSuccessThresholdFromUser();
                Console.WriteLine($"Attacker hits on {attackerHitValue}s.\n");

                var combatProcess = new CombatProcess(numberOfHitDice, attackerHitValue);

                // Perform hit roll
                ProjectHitRoll(combatProcess);
            }
        }

        #endregion
    }
}