namespace GladiatorArena.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public abstract class BaseController : Controller
    {
        protected readonly IAccountService accountService;

        public BaseController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
    }
}
