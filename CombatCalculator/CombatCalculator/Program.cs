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
        private static int GetPositiveIntegerFromUser()
        {
            Console.WriteLine("Enter a positive integer value ...");

            if (!int.TryParse(Console.ReadLine(), out int userInt) || userInt <= 0)
            {
                Console.WriteLine($"Invalid value, defaulting to 1.");
                userInt = 1;
            }

            Console.WriteLine("");
            return userInt;
        }

        /// <summary>
        /// Retrieves the success threshold value from the user.
        /// </summary>
        /// <returns>The success threshold.</returns>
        private static int GetDieSuccessThresholdFromUser()
        {
            Console.WriteLine($"Enter an integer value from 1 to 7 ...");

            if (!int.TryParse(Console.ReadLine(), out int successThreshold) || successThreshold < 1 || successThreshold > 7)
            {
                Console.WriteLine($"Invalid value, defaulting to 7.");
                successThreshold = 7;
            }

            Console.WriteLine("");
            return successThreshold;
        }

        /// <summary>
        /// Simulates rolling the hit roll of an attack.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="hitStat"></param>
        private static void CalculateHitRoll(AttackerDTO attacker)
        {
            Console.WriteLine($"Calculating Hit rolls for an attack with:\n"
                              + $" - {CombatMath.GetTotalNumberOfAttacks(attacker)} Hits,\n"
                              + $" - a successful Hit roll of {attacker.WeaponSkill}+");
            Console.WriteLine("");

            // Print stats
            Console.WriteLine($"Probability of any one hit roll succeeding: {CombatMath.GetProbabilityOfHit(attacker) * 100:F2}%");
            Console.WriteLine($"Mean: {CombatMath.GetMeanHits(attacker):F2}");
            Console.WriteLine($"Standard deviation: {CombatMath.GetStandardDeviationHits(attacker):F2}");
            Console.WriteLine("");

            // Print distributions of Hits
            Console.WriteLine($"Binomial Distribution of Hits:");
            Console.WriteLine(CombatMath.GetBinomialDistributionOfHits(attacker));
            Console.WriteLine("");
            Console.WriteLine($"Upper Cumulative Distribution of Hits:");
            Console.WriteLine(CombatMath.GetUpperCumulativeDistributionOfHits(attacker));
        }

        /// <summary>
        /// Simulates rolling the wound roll of an attack.
        /// </summary>
        /// <param name="attacker"></param>
        private static void CalculateWoundRoll(AttackerDTO attacker, DefenderDTO defender)
        {
            Console.WriteLine($"Calculating Wound rolls for an attack with;\n"
                              + $"- {attacker.WeaponAttacks} Hits,\n"
                              + $"- a successful Hit roll of {attacker.WeaponSkill}+,\n"
                              + $"- a successful Wound roll of {CombatMath.GetSuccessThresholdOfWound(attacker, defender)}+");
            Console.WriteLine("");

            // Print stats
            Console.WriteLine($"Probability of any one hit and wound roll succeeding: {CombatMath.GetProbabilityOfWound(attacker, defender) * 100:F2}%");
            Console.WriteLine($"Mean: {CombatMath.GetMeanWounds(attacker, defender):F2}");
            Console.WriteLine($"Standard deviation: {CombatMath.GetStandardDeviationWounds(attacker, defender):F2}");
            Console.WriteLine("");

            // Print distributions of successful wounds
            Console.WriteLine($"Binomial Distribution of Wounds:");
            Console.WriteLine(CombatMath.GetBinomialDistributionOfWounds(attacker, defender));
            Console.WriteLine("");
            Console.WriteLine($"Upper Cumulative Distribution of Wounds:");
            Console.WriteLine(CombatMath.GetUpperCumulativeDistributionOfWounds(attacker, defender));
        }

        /// <summary>
        /// Simulates rolling the armor save roll of an attack.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        private static void CalculateArmorSaveRoll(AttackerDTO attacker, DefenderDTO defender)
        {
            Console.WriteLine($"Calculating failed Save rolls for an attack with:"
                              + $"- {attacker.WeaponAttacks} Hits,\n"
                              + $"- a successful Hit roll of {attacker.WeaponSkill}+,\n"
                              + $"- a successful Wound roll of {CombatMath.GetSuccessThresholdOfWound(attacker, defender)}+,\n"
                              + $"- a successful Armor Save roll of {CombatMath.GetAdjustedArmorSave(attacker, defender)}+");
            Console.WriteLine("");

            // Print stats
            Console.WriteLine($"Probability of any hit and wound succeeding, and the armor save failing: {CombatMath.GetProbabilityOfFailedSave(attacker, defender) * 100:F2}%");
            Console.WriteLine($"Mean: {CombatMath.GetMeanFailedSaves(attacker, defender):F2}");
            Console.WriteLine($"Standard deviation: {CombatMath.GetStandardDeviationFailedSaves(attacker, defender):F2}");
            Console.WriteLine("");

            // Print distributions of failed saves
            Console.WriteLine($"Binomial Distribution of Failed Saves:");
            Console.WriteLine(CombatMath.GetBinomialDistributionOfFailSaves(attacker, defender));
            Console.WriteLine("");
            Console.WriteLine($"Upper Cumulative Distribution of Failed Saves:");
            Console.WriteLine(CombatMath.GetUpperCumulativeDistributionOfFailedSaves(attacker, defender));
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
                Console.WriteLine("---------- ++ Combat Calculator ++ ----------");
                Console.WriteLine("");

                // Get attacker data
                Console.WriteLine("Attacker Data: ");
                Console.WriteLine("");

                Console.WriteLine("Enter number of attacking models:");
                var attackerNumberOfModels = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter attacker's weapon Attacks stat:");
                var weaponAttacksStat = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter attacker's Weapon Skill stat:");
                var attackerWeaponSkill = GetDieSuccessThresholdFromUser();

                Console.WriteLine("Enter attacker's weapon Strength stat:");
                var attackerWeaponStrength = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter attacker's weapon Armor Pierce stat:");
                var attackerWeaponArmorPierce = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter attacker's weapon Damage stat:");
                var attackerWeaponDamage = GetPositiveIntegerFromUser();
                
                Console.WriteLine("");
                Console.WriteLine("");

                // Get defender data
                Console.WriteLine("Defender Data: ");
                Console.WriteLine("");

                Console.WriteLine("Enter number of defending models:");
                var defenderNumberOfModels = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter defender's Toughness stat:");
                var defenderToughness = GetPositiveIntegerFromUser();

                Console.WriteLine("Enter defender's Armor Save stat:");
                var defenderArmorSave = GetDieSuccessThresholdFromUser();

                Console.WriteLine("Enter defender's Invulnerable Save stat:");
                var defenderInvulnerableSave = GetDieSuccessThresholdFromUser();

                Console.WriteLine("Enter defender's Feel No Pain stat:");
                var defenderFeelNoPain = GetDieSuccessThresholdFromUser();

                Console.WriteLine("Enter defender's Wounds stat:");
                var defenderWounds = GetPositiveIntegerFromUser();

                // Create attacker object
                var attacker = new AttackerDTO
                {
                    NumberOfModels = attackerNumberOfModels,
                    WeaponAttacks = weaponAttacksStat,
                    WeaponSkill = attackerWeaponSkill,
                    WeaponStrength = attackerWeaponStrength,
                    WeaponArmorPierce = attackerWeaponArmorPierce,
                    WeaponDamage = attackerWeaponDamage,
                };

                // Create defender object
                var defender = new DefenderDTO
                {
                    NumberOfModels = defenderNumberOfModels,
                    Toughness = defenderToughness,
                    ArmorSave = defenderArmorSave,
                    InvulnerableSave = defenderInvulnerableSave,
                    FeelNoPain = defenderFeelNoPain,
                    Wounds = defenderWounds
                };

                // Print attacker and defender data
                Console.WriteLine("");
                Console.WriteLine($"{attacker}\n");
                Console.WriteLine($"{defender}\n");

                // Perform hit roll
                CalculateHitRoll(attacker);

                // Perform wound roll
                CalculateWoundRoll(attacker, defender);

                // Perform save roll
                CalculateArmorSaveRoll(attacker, defender);

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("");
            }
        }

        #endregion
    }
}