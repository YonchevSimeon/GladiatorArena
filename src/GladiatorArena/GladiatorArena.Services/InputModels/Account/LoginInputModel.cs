namespace GladiatorArena.Services.InputModels.Account
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    using Utilities.Mapping;
    using static Utilities.Constants.ErrorMessages;

    public class LoginInputModel : IMapFrom<GladiatorArenaUser>
    {
        [Required(ErrorMessage = RequiredError)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
