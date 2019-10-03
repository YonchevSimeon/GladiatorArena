namespace GladiatorArena.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder
                .HasKey(h => h.Id);

            builder
                .HasOne(h => h.Owner)
                .WithOne(gau => gau.Hero)
                .HasForeignKey<GladiatorArenaUser>(gau => gau.HeroId);
        }
    }
}
