namespace GladiatorArena.Data
{
    using Configurations;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class GladiatorArenaDbContext : IdentityDbContext<GladiatorArenaUser>
    {
        public GladiatorArenaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GladiatorArenaUserConfiguration());
            builder.ApplyConfiguration(new HeroConfiguration());
        }
    }
}
