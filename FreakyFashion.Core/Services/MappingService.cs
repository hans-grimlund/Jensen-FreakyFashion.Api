using FreakyFashion.Core.Interfaces;
using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Services;

public class MappingService : IMappingService
{
    public ItemEntity ToItemEntity(IFormCollection formData)
    {
        return new ItemEntity()
        {
            Name = formData["name"]!,
            DisplayName = formData["displayName"]!,
            Description = formData["description"]!,
            Price = int.Parse(formData["price"]!)
        };
    }

    public ItemDto ToItemDto(ItemEntity model)
    {
        return new ItemDto()
        {
            Id = model.Id,
            Name = model.Name,
            DisplayName = model.DisplayName,
            Description = model.Description,
            Price = model.Price
        };
    }

    public List<ItemDto> ToItemDto(List<ItemEntity> models)
    {
        List<ItemDto> dtos = [];
        foreach (var model in models)    
        {
            dtos.Add(ToItemDto(model));
        }
        return dtos;
    }
}