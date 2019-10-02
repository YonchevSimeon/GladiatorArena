namespace GladiatorArena.Services.ViewModels.Account
{
    using Models;
    using Utilities.Mapping;

    public class AccountProfileViewModel : IMapFrom<GladiatorArenaUser>
    {
        public string UserName { get; set; }
    }
}
///
/// Update later (add more propeties and custom mapping) when we have more info to show.
///
