namespace GladiatorArena.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.InputModels.Account;
    using Services.ViewModels.Account;
    using System.Net;
    using System.Threading.Tasks;

    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IAccountService accountService) 
            : base(accountService)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) return this.RedirectToAction("Index", "Home");

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if(this.ModelState.IsValid)
            {
                await this.accountService.LogInAsync(model);

                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                ViewResult viewResult = this.View("Error", this.ModelState);
                viewResult.StatusCode = (int)HttpStatusCode.BadRequest;

                return viewResult;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated) return this.RedirectToAction("Index", "Home");

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.accountService.RegisterAsync(model);

                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                ViewResult viewResult = this.View("Error", this.ModelState);
                viewResult.StatusCode = (int)HttpStatusCode.BadRequest;

                return viewResult;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string username)
        {
            AccountProfileViewModel profile = await this.accountService.GetProfileByUserNameAsync(username);

            //
            // Add error if profile is null (username does not exists)!!!
            //

            return this.View(profile);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this.accountService.LogOutAsync();

            return this.RedirectToAction(nameof(Login));
        }
    }
}
