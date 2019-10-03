namespace GladiatorArena.Models
{
    using Microsoft.AspNetCore.Identity;

    public class GladiatorArenaUser : IdentityUser
    {
        public GladiatorArenaUser()
        {
        }

        public string HeroId { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
