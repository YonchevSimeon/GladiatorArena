namespace GladiatorArena.Utilities.Constants
{
    public static class ErrorMessages
    {
        #region errors
        public const string RequiredError = "The {0} is a required field!";

        public const string InvalidUserNameError = "The {0}, must be between {2} and {1} characters long!";

        public const string InvalidPasswordError = "The {0}, must be between {2} and {1} characters long!";

        public const string PasswordsDoNotMatchError = "The password and confirmation password does not match!";

        public const string InvalidUserNameOrPasswordError = "Invalid username or password!";

        public const string InvalidEmailError = "This is not a valid email address!";

        public const string InvalidUserId = "This user does not exists!";
        #endregion

        #region messages
        public const string UserNameExistsMessage = "There is already an user registered with this username.";

        public const string EmailAddressExistsMessage = "There is already an user registered with this email.";
        #endregion
    }
}
