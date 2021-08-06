namespace Astronomyfi.Services.Data
{
    using System.Threading.Tasks;

    using Astronomyfi.Web.ViewModels.Images;

    public interface IImagesService
    {
        Task PostAsync(AddImageInputModel input);

        TModel GetImage<TModel>(int imageId);
    }
}
