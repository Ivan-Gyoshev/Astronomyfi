namespace Astronomyfi.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Astronomyfi.Common;
    using Astronomyfi.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            const string adminEmail = "admin@astronomyfi.com";
            const string adminUserName = "AstroA";
            const string adminPassword = "admin12";

            var user = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminUserName,
            };

            await userManager.CreateAsync(user, adminPassword);

            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            await dbContext.SaveChangesAsync();

        }
    }
}
