namespace GladiatorArena.Services.Contracts
{
    using InputModels.Account;
    using Models;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ViewModels.Account;

    public interface IAccountService
    {
        Task LogInAsync(LoginInputModel model);

        Task RegisterAsync(RegisterInputModel model);

        Task LogOutAsync();

        Task<GladiatorArenaUser> GetLoggedInUserAsync(ClaimsPrincipal claimsPrincipal);

        /// <summary>
        /// Will use later
        /// </summary>
        Task<AccountProfileViewModel> GetProfileByUserNameAsync(string userName);

        bool UserNameExists(string userName);

        bool EmailAddressExists(string emailAddress);
    }
}
