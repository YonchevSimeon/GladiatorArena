namespace GladiatorArena.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using InputModels.Account;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enums;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ViewModels.Account;

    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<GladiatorArenaUser> userManager;
        private readonly SignInManager<GladiatorArenaUser> signInManager;
        private readonly IConfigurationProvider configurationProvider;

        public AccountService(IMapper mapper, 
            GladiatorArenaDbContext context, 
            UserManager<GladiatorArenaUser> userManager,
            SignInManager<GladiatorArenaUser> signInManager,
            IConfigurationProvider configurationProvider)
            : base(mapper, context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configurationProvider = configurationProvider;
        }

        public async Task LogInAsync(LoginInputModel model)
        {
            GladiatorArenaUser user = this.mapper.Map<LoginInputModel, GladiatorArenaUser>(model);

            await this.LogInAsync(user, model.Password);
        }

        public async Task RegisterAsync(RegisterInputModel model)
        {
            GladiatorArenaUser user = this.mapper.Map<RegisterInputModel, GladiatorArenaUser>(model);

            await this.RegisterAsync(user, model.Password);
        }

        public async Task LogOutAsync()
            => await this.signInManager.SignOutAsync();

        public async Task<GladiatorArenaUser> GetLoggedInUserAsync(ClaimsPrincipal claimsPrincipal)
            => await this.userManager.GetUserAsync(claimsPrincipal);

        public async Task<AccountProfileViewModel> GetProfileByUserNameAsync(string userName)
            => await this.context
                .Users
                .Where(u => u.UserName == userName)
                .ProjectTo<AccountProfileViewModel>(this.configurationProvider)
                .FirstOrDefaultAsync();

        public bool UserNameExists(string userName)
            => this.context.Users.Any(u => u.UserName == userName);

        public bool EmailAddressExists(string emailAddress)
            => this.context.Users.Any(u => u.Email == emailAddress);

        #region private methods
        private async Task LogInAsync(GladiatorArenaUser user, string password)
            => await this.signInManager.PasswordSignInAsync(user.UserName, password, false, lockoutOnFailure: true);

        private async Task<IdentityResult> RegisterAsync(GladiatorArenaUser user, string password)
        {
            IdentityResult identityResult = await this.userManager.CreateAsync(user, password);

            if (identityResult.Succeeded)
            {
                if (this.context.Users.Count() == 1)
                    await this.userManager.AddToRoleAsync(user, Role.Administrator.ToString());
                else
                    await this.userManager.AddToRoleAsync(user, Role.User.ToString());

                await this.signInManager.SignInAsync(user, isPersistent: false);
            }

            return identityResult;
        }
        #endregion
    }
}
