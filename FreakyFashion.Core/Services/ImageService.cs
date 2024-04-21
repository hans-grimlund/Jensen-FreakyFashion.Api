using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FreakyFashion.Core.Interfaces;
using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Services;

public class ImageService : IImageService
{
    public async Task UploadItemImage(IFormFile file, string fileName)
    {
        BlobServiceClient blobServiceClient = new(Secrets.StConnString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient("items");
        
        using MemoryStream stream = new();
        await file.CopyToAsync(stream);
        stream.Seek(0, SeekOrigin.Begin);

        var blobHeaders = new BlobHttpHeaders{ ContentType = "image/jpeg" };

        var blobClient = blobContainerClient.GetBlobClient($"{fileName}.jpeg");
        await blobClient.UploadAsync(stream, blobHeaders);
    }
}