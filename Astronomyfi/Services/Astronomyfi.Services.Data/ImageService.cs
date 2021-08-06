namespace Astronomyfi.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Common;
    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Identity;

    public class ImageService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(IDeletableEntityRepository<Image> imagesRepository, ICloudinaryService cloudinaryService)
        {
            this.imagesRepository = imagesRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task PostAsync(AddImageInputModel input)
        {

            var image = new Image
            {
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                AuthorId = input.AuthorId,
            };

            await this.imagesRepository.AddAsync(image);

            await this.imagesRepository.SaveChangesAsync();

            if (input.NewImage != null)
            {
                var imageUrl = await this.cloudinaryService.UploadPhotoAsync(input.NewImage, input.AuthorId, GlobalConstants.CloudFolderForSpaceImages);

                image.ImageUrl = imageUrl;
            }

            await this.imagesRepository.SaveChangesAsync();
        }

        public TModel GetImage<TModel>(int imageId)
            => this.imagesRepository.All()
            .Where(i => i.Id == imageId)
            .To<TModel>()
            .FirstOrDefault();

        private Image GetImage(int id)
            => this.imagesRepository.All()
            .FirstOrDefault(i => i.Id == id);
    }
}
