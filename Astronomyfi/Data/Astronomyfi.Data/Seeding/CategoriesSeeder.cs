namespace Astronomyfi.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Galaxies",
                Description = "All different topics and questions about Galaxies",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/NGC_4414_%28NASA-med%29.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Stars and Planets",
                Description = "All different topics and questions about Stars and Planets",
                ImageUrl = "https://www.universetoday.com/wp-content/uploads/2008/07/extra_solar_planet.jpg",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Science and discoveries",
                Description = "Discussions about science and new inventions",
                ImageUrl = "https://www.insidescience.org/sites/default/files/2020-07/gravlensing_color_glass4.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
