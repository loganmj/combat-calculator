using System.Text;

namespace CombatCalculator
{
    /// <summary>
    /// Represents a binomial distribution of trial data, represented as a data map.
    /// The key is the number of successes.
    /// The value is the probability of that result.
    /// </summary>
    public class BinomialProbability : Dictionary<int, double>
    {
        #region Public Methods

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
