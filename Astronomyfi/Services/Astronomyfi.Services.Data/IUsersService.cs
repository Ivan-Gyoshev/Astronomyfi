namespace Astronomyfi.Services.Data
{
    public interface IUsersService
    {
        TModel GetUser<TModel>(string userId);
    }
}
