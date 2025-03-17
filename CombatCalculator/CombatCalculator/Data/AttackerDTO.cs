namespace CombatCalculator.Data
{
    /// <summary>
    /// A data transfer object representing the attacker in a combat scenario.
    /// </summary>
    internal class AttackerDTO
    {
        #region Properties

        /// <summary>
        /// The number of attacks the attacker is making.
        /// </summary>
        public int NumberOfAttacks { get; set; }

        /// <summary>
        /// The ballistic/weapon skill threshold value of the attacker.
        /// </summary>
        public int HitSkill { get; set; }

        /// <summary>
        /// The strength of the attacker's weapon.
        /// </summary>
        public int WeaponStrength { get; set; }

        /// <summary>
        /// The armor pierce value of the attacker's weapon.
        /// </summary>
        public int WeaponArmorPierce { get; set; }

        /// <summary>
        /// The damage value of the attacker's weapon.
        /// </summary>
        public int WeaponDamage { get; set; }

        #endregion
    }
}
