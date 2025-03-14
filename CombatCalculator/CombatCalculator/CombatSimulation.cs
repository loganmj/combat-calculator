using System.Text;

namespace CombatCalculator
{
    /// <summary>
    /// Represents a binomial distribution of trials and successes.
    /// </summary>
    public class CombatSimulation(int numberOfTrials, int successThreshold)
    {
        #region Properties

        /// <summary>
        /// The number of trials included in the distribution.
        /// </summary>
        public int NumberOfTrials = numberOfTrials;

        /// <summary>
        /// The minimum value that a die result must have in order to succeed.
        /// </summary>
        public int SuccessThreshold = successThreshold;

        #endregion

        #region Private Methods

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
        /// Returns the probability of succeeding a roll with a single dice, given the desired success threshold.
        /// </summary>
        /// <param name="successThreshold"></param>
        /// <returns>A double value containing the probability of success for a single trial.</returns>
        public double GetProbabilityOfSuccessForSingleTrial()
        {
            return (6 - (SuccessThreshold - 1)) / 6.0;
        }

        /// <summary>
        /// Retrieves the binomial distribution of trial data.
        /// </summary>
        /// <returns>A binomial distribution of results and their respective probabilities.</returns>
        public BinomialDistribution GetBinomialDistribution()
        {
            var distribution = new BinomialDistribution();

            for (int i = 0; i <= NumberOfTrials; i++)
            {
                distribution.Add(i, BinomialProbability(NumberOfTrials, i, GetProbabilityOfSuccessForSingleTrial()));
            }

            return distribution;
        }

        public double GetMean() 
        {
            return NumberOfTrials * GetProbabilityOfSuccessForSingleTrial();
        }

        public double GetStandardDeviation() 
        {
            var probabilityOfSingleSuccess = GetProbabilityOfSuccessForSingleTrial();
            return Math.Sqrt(NumberOfTrials * probabilityOfSingleSuccess * (1 - probabilityOfSingleSuccess));
        }

        public double GetMode() 
        {
            return Math.Floor((NumberOfTrials + 1) * GetProbabilityOfSuccessForSingleTrial());
        }

        #endregion
    }
}
