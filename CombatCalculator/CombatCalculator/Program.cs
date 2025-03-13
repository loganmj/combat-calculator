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
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <param name="successThreshold"></param>
        /// <returns></returns>
        private static double GetProbabilityOfSuccessWithOneDie(int successThreshold) 
        {
            return (6 - (successThreshold - 1)) / 6.0;
        }

        /// <summary>
        /// Simulates the rolling of the given number of dice.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="successThreshold"></param>
        private static void RollDice(int numberOfDice, int successThreshold)
        {
            Console.WriteLine($"Rolling {numberOfDice} dice, succeeding on a roll of {successThreshold}+ ...");

            // Get the probability of success with one die
            var probabilityOfSuccessWithOneDie = GetProbabilityOfSuccessWithOneDie(successThreshold);
            Console.WriteLine($"Probability of succeeding with one die: {GetProbabilityOfSuccessWithOneDie(successThreshold)}");
            Console.WriteLine("\n");

            // Determine binomial distribution of success with all dice
            Console.WriteLine($"Binomial distribution for {numberOfDice} dice rolling {successThreshold}+:");
            var distribution = GetBinomialDistribution(numberOfDice, probabilityOfSuccessWithOneDie);

            // Print the distribution
            foreach (var result in distribution) 
            {
                Console.WriteLine($"Probability of {result.Key} success{(result.Key > 1 ? "es" : "")} = {(result.Value * 100).ToString("F2")}%");
            }

            // Print distribution stats
            var averageNumberOfSuccesses = distribution.Aggregate((left, right) => left.Value > right.Value ? left : right).Key;
            Console.WriteLine($"Average number of successes: {averageNumberOfSuccesses}");
            
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Prints the binomial distribution values for rolling a given number of dice with a given success threshold.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="probabilityOfSuccessWithOneDie"></param>
        private static Dictionary<int, double> GetBinomialDistribution(int numberOfDice, double probabilityOfSuccessWithOneDie) 
        {
            var distribution = new Dictionary<int, double>();
            for (int i = 0; i <= numberOfDice; i++)
            {
                double probability = BinomialProbability(numberOfDice, i, probabilityOfSuccessWithOneDie);
                distribution.Add(i, probability);
            }

            return distribution;
        }

        /// <summary>
        /// Calculates the probability of a given number of successes 
        /// when a given number of dice are rolled with a given success threshold.
        /// </summary>
        /// <param name="n">The total number of dice.</param>
        /// <param name="k">The number of successes.</param>
        /// <param name="p">The probability of success for a single die roll.</param>
        /// <returns></returns>
        private static double BinomialProbability(int n, int k, double p)
        {
            double binomialCoefficient = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return binomialCoefficient * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
        }

        /// <summary>
        /// Calculates the factorial of a number.
        /// Factorials are denoted by the syntax "n!".
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static double Factorial(int number)
        {
            double result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
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
                var numberOfDice = GetNumberOfDiceFromUser();
                var successThreshold = GetSuccessThresholdFromUser();

                // Roll dice
                RollDice(numberOfDice, successThreshold);
            }
        }

        #endregion
    }
}