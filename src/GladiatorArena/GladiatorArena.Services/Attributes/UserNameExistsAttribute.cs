namespace GladiatorArena.Services.Attributes
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Utilities.Constants.ErrorMessages;

    [AttributeUsage(AttributeTargets.Property)]
    public class UserNameExistsAttribute : ValidationAttribute
    {
        private IAccountService accountService;

        public UserNameExistsAttribute() { }

        public UserNameExistsAttribute(string errorMessage) : base(errorMessage) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.accountService = (IAccountService)validationContext.GetService(typeof(IAccountService));

            if (!this.accountService.UserNameExists(value.ToString())) return ValidationResult.Success;
            else return new ValidationResult(UserNameExistsMessage);
        }
    }
}
