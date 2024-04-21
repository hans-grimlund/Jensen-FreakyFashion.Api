using FreakyFashion.Core.Interfaces;
using FreakyFashion.Data.Interfaces;
using FreakyFashion.Domain.Responses;
using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Services;

public class ItemService(IItemRepo itemRepo, IMappingService mappingService, IImageService imageService, ILoggingService loggingService) : IItemService
{
    public async Task<Status> AddItem(IFormCollection formData)
    {
        var itemEntity = mappingService.ToItemEntity(formData);
        
        if ((await itemRepo.GetItem(itemEntity.Name)) != null)
            return Status.BadRequest;
        
        var image = formData.Files[0];

        await itemRepo.AddItem(itemEntity);
        await imageService.UploadItemImage(image, itemEntity.Name);
        
        loggingService.LogInfo(itemEntity.Name + " was added");
        return Status.Ok;
    }

    public async Task<Status> DeleteItem(string sku)
    {
        var product = await itemRepo.GetItem(sku);
        if (product == null)
            return Status.NotFound;

        await itemRepo.DeleteItem((sku));
        
        loggingService.LogInfo(sku + " was deleted");
        return Status.Ok;
    }

    public async Task<GetItemResponse> GetItems(Filters filters)
    {
        List<ItemEntity> results = new();
        if (filters.ItemId != 0)
            results.Add(await itemRepo.GetItem(filters.ItemId));
        
        else if (filters.ItemName != string.Empty)
            results.Add(await itemRepo.GetItem(filters.ItemName));
        
        else
            results = await itemRepo.GetItems(filters);
            
        return results.Count < 1 ? new GetItemResponse(status: Status.NotFound) :
            new GetItemResponse(status: Status.Ok, items: mappingService.ToItemDto(results));
    }
}