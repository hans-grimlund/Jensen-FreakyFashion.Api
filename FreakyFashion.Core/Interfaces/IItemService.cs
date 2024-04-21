using FreakyFashion.Domain;
using FreakyFashion.Domain.Responses;
using Microsoft.AspNetCore.Http;

namespace FreakyFashion.Core.Interfaces;

public interface IItemService
{
    Task<Status> AddItem(IFormCollection formData);
    Task<Status> DeleteItem(string sku);
    Task<GetItemResponse> GetItems(Filters filters);
}