namespace Astronomyfi.Services.Data.Images
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Images;

    public interface IImagesService
    {
        Task PostAsync(AddImageInputModel input);

        Task ApproveAsync(int imageId);

        TModel GetImage<TModel>(int imageId);

        IEnumerable<TModel> GetAllApprovedImages<TModel>();

        IEnumerable<TModel> GetAllUnapprovedImages<TModel>();
    }
}
