namespace Astronomyfi.Services
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadPhotoAsync(IFormFile file, string fileName, string folder);
    }
}
