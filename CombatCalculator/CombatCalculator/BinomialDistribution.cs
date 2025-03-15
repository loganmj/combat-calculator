using System.Text;

namespace CombatCalculator
{
    /// <summary>
    /// Represents a binomial distribution of trial data, represented as a data map.
    /// The key is the number of successes.
    /// The value is the probability of that result.
    /// </summary>
    public class BinomialDistribution : Dictionary<int, double>
    {
        #region Public Methods

        /// <summary>
        /// Returns the mean value of the distribution.
        /// </summary>
        /// <returns></returns>
        public double GetMean()
        {
            double mean = 0;
            foreach (var result in this)
            {
                mean += result.Key * result.Value;
            }
            return mean;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            foreach (var result in this)
            {
                stringBuilder.AppendLine($"P({result.Key}) = {(result.Value * 100):F2}%");
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
