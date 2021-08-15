namespace Astronomyfi.Services.Data.Tests
{
    using System;
    using System.Reflection;

    using Astronomyfi.Data;
    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Repositories;
    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Services.Data.Comments;
    using Astronomyfi.Services.Data.Images;
    using Astronomyfi.Services.Data.Posts;
    using Astronomyfi.Services.Data.Users;
    using Astronomyfi.Services.Data.Votes;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web;
    using Astronomyfi.Web.ViewModels;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Account = CloudinaryDotNet.Account;

    public abstract class BaseTestsService : IDisposable
    {
        protected BaseTestsService()
        {
            var services = SetServices();

            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            SetServices();
        }

        private static ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            Account claudinaryInformation = new(
              "Cloudinary:CloudName",
              "Cloudinary:ApiKey",
              "Cloudinary:ApiSecret");

            Cloudinary cloudinary = new(claudinaryInformation);

            services.AddSingleton(cloudinary);

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IVotesService, VoteService>();
            services.AddTransient<IImagesService, ImageService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();

            return services;
        }
    }
}
