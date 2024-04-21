using FreakyFashion.Domain;

namespace FreakyFashion.Data.Interfaces;

public interface IItemRepo
{
    Task AddItem(ItemEntity item);
    Task EditItem(ItemEntity item);
    Task DeleteItem(string sku);
    Task<List<ItemEntity>> GetItems(Filters filters);
    Task<ItemEntity> GetItem(string sku);
    Task<ItemEntity> GetItem(int itemId);
}