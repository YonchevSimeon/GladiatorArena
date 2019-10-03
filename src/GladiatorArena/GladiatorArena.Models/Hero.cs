namespace GladiatorArena.Models
{
    using System;
    using static Utilities.Constants.ModelConstants.Hero;
    public class Hero : BaseModel<string>
    {
        public Hero()
        {
            this.Strength = StrengthDefaultValue;

            this.Armour = ArmourDefaultValue;
            this.MinDamage = MinDamageDefaultValue + this.ExtraDamageFromStrength();
            this.MaxDamage = MaxDamageDefaultValue + this.ExtraDamageFromStrength();
        }

        #region Stats
        /// <summary>
        /// Add more stats later
        /// </summary>
        public int Strength { get; set; }
        #endregion

        public int Armour { get; set; }

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }

        private int ExtraDamageFromStrength()
            => (int)Math.Floor(this.Strength / StrengthDivider);

        public string OwnerId { get; set; }
        public virtual GladiatorArenaUser Owner { get; set; }
    }
}
