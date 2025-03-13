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
        /// <returns></returns>
        private static int GetNumberOfDiceFromUser()
        {
            Console.WriteLine("Enter number of dice to roll:");
            return !int.TryParse(Console.ReadLine(), out int numberOfDice) ? 0 : numberOfDice;
        }

        /// <summary>
        /// Simulates the rolling of the given number of dice.
        /// </summary>
        /// <param name="numberOfDice"></param>
        private static void RollDice(int numberOfDice)
        {
            Console.WriteLine($"Rolling {numberOfDice} dice ...\n");
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

                // Roll dice
                RollDice(numberOfDice);
            }
        }

        #endregion
    }
}