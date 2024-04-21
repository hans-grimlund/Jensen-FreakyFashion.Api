using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Interfaces;

public interface IImageService
{
    Task UploadItemImage(IFormFile image, string fileName);
}