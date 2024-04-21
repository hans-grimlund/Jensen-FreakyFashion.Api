using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Interfaces;

public interface IMappingService
{
    ItemEntity ToItemEntity(IFormCollection formData);
    ItemDto ToItemDto(ItemEntity model);
    List<ItemDto> ToItemDto(List<ItemEntity> models);
}