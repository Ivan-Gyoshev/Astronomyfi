namespace Astronomyfi.Services.Data
{
    using System.Linq;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationUser> usersRepository;

        public UsersService(IRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public TModel GetUser<TModel>(string userId)
            => this.usersRepository
            .All()
            .Where(u => u.Id == userId)
            .To<TModel>()
            .FirstOrDefault();
    }
}
