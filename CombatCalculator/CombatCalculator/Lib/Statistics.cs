﻿using CombatCalculator.Data;

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
        /// Calculates the binomial distribution of trial data.
        /// </summary>
        /// <param name="numberOfTrials">The number of trials in the process.</param>
        /// <param name="probability">The probability of success for a single trial.</param>
        /// <returns>A binomial distribution of trial results and their respective probabilities.</returns>
        public static ProbabilityDistribution BinomialDistribution(int numberOfTrials, double probability)
        {
            var distribution = new ProbabilityDistribution();

            for (int k = 0; k <= numberOfTrials; k++)
            {
                distribution.Add(k, ProbabilityMassFunction(numberOfTrials, k, probability));
            }

            return distribution;
        }

        /// <summary>
        /// Calculates the lower cumulative probability of trial data.
        /// Lower cumulative probability is the probability of achieving a result less than or equal to the given number of successes.
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <param name="probability"></param>
        /// <returns>A double containing the cumulative probability value.</returns>
        public static double LowerCumulativeProbability(int numberOfTrials, int numberOfSuccesses, double probability)
        {
            double cumulativeProbability = 0;

            for (int i = 0; i <= numberOfSuccesses; i++)
            {
                cumulativeProbability += ProbabilityMassFunction(numberOfTrials, i, probability);
            }

            return cumulativeProbability;
        }

        /// <summary>
        /// Calculates the lower cumulative distribution of trial data.
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probability"></param>
        /// <returns>A cumulative distribution of trial results and their respective probabilities.</returns>
        public static ProbabilityDistribution LowerCumulativeDistribution(int numberOfTrials, double probability)
        {
            var distribution = new ProbabilityDistribution();

            for (int k = 0; k <= numberOfTrials; k++)
            {
                distribution.Add(k, LowerCumulativeProbability(numberOfTrials, k, probability));
            }

            return distribution;
        }

        /// <summary>
        /// Calculates the upper cumulative probability of trial data.
        /// Upper cumulative probability is the probability of achieving a result greater than or equal to the given number of successes.
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <param name="probability"></param>
        /// <returns>A double containing the cumulative probability value.</returns>
        public static double UpperCumulativeProbability(int numberOfTrials, int numberOfSuccesses, double probability)
        {
            double cumulativeProbability = 0;

            for (int i = numberOfSuccesses; i <= numberOfTrials; i++)
            {
                cumulativeProbability += ProbabilityMassFunction(numberOfTrials, i, probability);
            }

            return cumulativeProbability;
        }

        /// <summary>
        /// Calculates the upper cumulative distribution of trial data.
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probability"></param>
        /// <returns></returns>
        public static ProbabilityDistribution UpperCumulativeDistribution(int numberOfTrials, double probability)
        {
            var distribution = new ProbabilityDistribution();

            for (int k = 0; k <= numberOfTrials; k++)
            {
                distribution.Add(k, UpperCumulativeProbability(numberOfTrials, k, probability));
            }

            return distribution;
        }

        /// <summary>
        /// Calculates the mean value of a probability distribution.
        /// </summary>
        /// <param name="distribution"></param>
        /// <returns></returns>
        public static double GetMean(this ProbabilityDistribution distribution)
        {
            double mean = 0;

            foreach (var result in distribution)
            {
                mean += result.Key * (double)result.Value;
            }

            return mean;
        }

        /// <summary>
        /// Calculates the median value of a probability distribution.
        /// </summary>
        /// <param name="distribution"></param>
        /// <returns></returns>
        public static int GetMedian(this ProbabilityDistribution distribution)
        {
            double cumulativeProbability = 0.5;

            foreach (var result in distribution)
            {
                cumulativeProbability -= result.Value;

                if (cumulativeProbability <= 0)
                {
                    return result.Key;
                }
            }

            return 0;
        }

        /// <summary>
        /// Calculates the mode value of a probability distribution.
        /// </summary>
        /// <param name="distribution"></param>
        /// <returns></returns>
        public static int GetMode(this ProbabilityDistribution distribution)
        {
            return distribution.Aggregate((max, result) => result.Value > max.Value ? result : max).Key;
        }

        /// <summary>
        /// Calculates the standard deviation of a probability distribution.
        /// </summary>
        /// <param name="distribution"></param>
        /// <returns></returns>
        public static double GetStandardDeviation(this ProbabilityDistribution distribution)
        {
            double variance = 0;

            foreach (var result in distribution)
            {
                variance += Math.Pow(result.Key - (double)GetMean(distribution), 2) * result.Value;
            }

            return Math.Sqrt(variance);
        }

        #endregion
    }
}
