namespace GladiatorArena.Web.Infrastructure
{
    using Microsoft.AspNetCore.Identity;
    using Models.Enums;
    using System.Threading.Tasks;

    public static class Seeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            bool adminRoleExists = await roleManager.RoleExistsAsync(Role.Administrator.ToString());
            if (!adminRoleExists)
            {
                IdentityRole administratorRole = new IdentityRole()
                {
                    Name = Role.Administrator.ToString(),
                    NormalizedName = Role.Administrator.ToString().ToUpper(),
                    ConcurrencyStamp = 0.ToString()
                };

                IdentityResult identityResult = await roleManager.CreateAsync(administratorRole);
            }

            bool userRoleExists = await roleManager.RoleExistsAsync(Role.User.ToString());
            if (!userRoleExists)
            {
                IdentityRole userRole = new IdentityRole()
                {
                    Name = Role.User.ToString(),
                    NormalizedName = Role.User.ToString().ToUpper(),
                    ConcurrencyStamp = 1.ToString()
                };

                IdentityResult identityResult = await roleManager.CreateAsync(userRole);
            }
        }
    }
}
