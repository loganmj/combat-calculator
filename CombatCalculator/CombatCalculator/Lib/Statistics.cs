using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatCalculator.Lib
{
    /// <summary>
    /// A static class that provides statstical math functions.
    /// </summary>
    public static class Statistics
    {
        #region Public Methods

        /// <summary>
        /// Calculates the probability of success for a single trial.
        /// </summary>
        /// <param name="numberOfPossibleResults"></param>
        /// <param name="numberOfSuccessfulResults"></param>
        /// <returns></returns>
        public static double ProbabilityOfSuccess(int numberOfPossibleResults, int numberOfSuccessfulResults)
        {
            return (double)numberOfSuccessfulResults / numberOfPossibleResults;
        }

        /// <summary>
        /// Calculates the binomial coefficient, determining the number of combinations of k elements
        /// in a population of n, independent of order.
        /// </summary>
        /// <param name="totalPopulation">The population of the group or set.</param>
        /// <param name="combinationSize">The number elements in a unique combination.</param>
        /// <returns>A double value containing the binomial coefficient.</returns>
        public static double BinomialCoefficient(int totalPopulation, int combinationSize)
        {
            return MathFunctions.Factorial(totalPopulation) / (MathFunctions.Factorial(combinationSize) * MathFunctions.Factorial(totalPopulation - combinationSize));
        }

        /// <summary>
        /// Calculates the probability for the success of a given number of trials
        /// using a specified probability of success for a single trial.
        /// </summary>
        /// <param name="probability">Probability of success for a single trial.</param>
        /// <param name="numberOfTrials">Number of trials.</param>
        /// <returns>A double value containing the probability that all trials will be successful.</returns>
        public static double ProbabilityOfMultipleSuccesses(double probability, int numberOfTrials)
        {
            return Math.Pow(probability, numberOfTrials);
        }

        /// <summary>
        /// Calculates the probability for the success of a given number of trials
        /// using an array of probabilities that represent the probability of each successful trial.
        /// </summary>
        /// <param name="probability">Probability of success for a single trial.</param>
        /// <param name="numberOfTrials">Number of trials.</param>
        /// <returns>A double value containing the probability that all trials will be successful.</returns>
        public static double ProbabilityOfMultipleSuccesses(double[] probabilities)
        {
            double result = 1;

            foreach (var probability in probabilities)
            {
                result *= Math.Pow(probability, probabilities.Length);
            }

            return result;
        }

        /// <summary>
        /// Calculates the probability mass function for a given number of successes 
        /// when a given number of dice are rolled with a given success threshold.
        /// The function can be broken down as a combination of the following:
        /// - The binomial coefficient, describing the number of unique combinations of results that can contain the desired number of successes.
        /// - The probability of finding the exact specified number of successful results.
        /// - The probability of finding the remaining results to be failures.
        /// </summary>
        /// <param name="numberOfTrials">The total number of dice.</param>
        /// <param name="numberOfSuccesses">The number of successes.</param>
        /// <param name="probability">The probability of success for a single die roll.</param>
        /// <returns></returns>
        public static double ProbabilityMassFunction(int numberOfTrials, int numberOfSuccesses, double probability)
        {
            return BinomialCoefficient(numberOfTrials, numberOfSuccesses)
                   * ProbabilityOfMultipleSuccesses(probability, numberOfSuccesses)
                   * ProbabilityOfMultipleSuccesses(1 - probability, numberOfTrials - numberOfSuccesses);
        }

        /// <summary>
        /// Retrieves the binomial distribution of trial data.
        /// </summary>
        /// <param name="numberOfTrials">The number of trials in the process.</param>
        /// <param name="probability">The probability of success for a single trial.</param>
        /// <returns>A binomial distribution of trial results and their respective probabilities.</returns>
        public static BinomialDistribution BinomialDistribution(int numberOfTrials, double probability)
        {
            var distribution = new BinomialDistribution();

            for (int i = 0; i <= numberOfTrials; i++)
            {
                distribution.Add(i, ProbabilityMassFunction(numberOfTrials, i, probability));
            }

            return distribution;
        }

        /// <summary>
        /// Gets the projected mean value for a set of trials.
        /// </summary>
        /// <param name="numberOfTrials">The total number of trials.</param>
        /// <param name="probability">The probability of success for a single trial.</param>
        /// <returns></returns>
        public static double BinomialMean(int numberOfTrials, double probability)
        {
            return numberOfTrials * probability;
        }

        /*

        public static double BinomialMode() { }
        public static double BinomialStandardDeviation() { }

        */

        #endregion
    }
}
