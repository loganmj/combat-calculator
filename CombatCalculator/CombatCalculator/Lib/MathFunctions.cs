using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatCalculator.Lib
{
    /// <summary>
    /// A static helper class that provides basic math functions.
    /// </summary>
    public static class MathFunctions
    {
        #region Public Methods

        /// <summary>
        /// Calculates the factorial of a number.
        /// Factorials are denoted by the syntax "n!".
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double Factorial(int number)
        {
            double result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        #endregion
    }
}
