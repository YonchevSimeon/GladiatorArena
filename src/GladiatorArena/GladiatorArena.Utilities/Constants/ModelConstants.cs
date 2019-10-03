namespace GladiatorArena.Utilities.Constants
{
    public static class ModelConstants
    {
        public static class Account
        {
            public const int UserNameMinLength = 4;
            public const int UserNameMaxLength = 12;

            public const int PasswordMinLength = 4;
            public const int PasswordMaxLength = 12;
        }

        public static class Hero
        {
            #region extras
            public const double StrengthDivider = 10.0;
            #endregion

            public const int StrengthDefaultValue = 5;

            public const int MinDamageDefaultValue = 0;

            public const int MaxDamageDefaultValue = 2;

            public const int ArmourDefaultValue = 0;
        }
    }
}
