namespace GladiatorArena.Services.InputModels.Account
{
    using Attributes;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using Utilities.Mapping;
    using static Utilities.Constants.ErrorMessages;
    using static Utilities.Constants.ModelConstants.Account;

    public class RegisterInputModel : IMapFrom<GladiatorArenaUser>
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(UserNameMaxLength, ErrorMessage = InvalidUserNameError, MinimumLength = UserNameMinLength)]
        [UserNameExists(ErrorMessage = UserNameExistsMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [EmailAddress(ErrorMessage = InvalidEmailError)]
        [EmailAddressExists(ErrorMessage = EmailAddressExistsMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordError, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = PasswordsDoNotMatchError)]
        public string Password { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordError, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordsDoNotMatchError)]
        public string ConfirmPassword { get; set; }
    }
}
