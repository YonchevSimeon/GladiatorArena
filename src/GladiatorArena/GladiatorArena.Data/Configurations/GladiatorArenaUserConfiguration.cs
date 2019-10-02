namespace GladiatorArena.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GladiatorArenaUserConfiguration : IEntityTypeConfiguration<GladiatorArenaUser>
    {
        public void Configure(EntityTypeBuilder<GladiatorArenaUser> builder)
        {
        }
    }
}
