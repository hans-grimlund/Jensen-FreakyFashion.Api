using System.Data;
using Dapper;
using FreakyFashion.Data.Interfaces;
using FreakyFashion.Domain;
using Microsoft.Data.SqlClient;

namespace FreakyFashion.Data.Repository;

public class ItemRepo : IItemRepo
{
    public async Task AddItem(ItemEntity item)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);

        var parameters = new DynamicParameters();
        parameters.Add("@Name", item.Name);
        parameters.Add("@DisplayName", item.DisplayName);
        parameters.Add("@Description", item.Description);
        parameters.Add("@Price", item.Price);

        await conn.ExecuteAsync("InsertItem", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task EditItem(ItemEntity item)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);
        
        var parameters = new DynamicParameters();
        parameters.Add("@Name", item.Name);
        parameters.Add("@DisplayName", item.DisplayName);
        parameters.Add("@Description", item.Description);
        parameters.Add("@Price", item.Price);

        await conn.ExecuteAsync("UpdateItem", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteItem(string sku)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);
        
        var parameters = new DynamicParameters();
        parameters.Add("@SKU", sku);

        await conn.ExecuteAsync("DeleteItem", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<ItemEntity>> GetItems(Filters filters)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);
        
        var parameters = new DynamicParameters();
        parameters.Add("@Start", filters.Start);
        parameters.Add("@End", filters.End);
        parameters.Add("@SearchTerm", filters.SearchTerm);

        var items = (await conn.QueryAsync<ItemEntity>("SelectItems", parameters,
            commandType: CommandType.StoredProcedure)).ToList();

        return items;
    }

    public async Task<ItemEntity> GetItem(string sku)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);
        
        var parameters = new DynamicParameters();
        parameters.Add("@Name", sku);

            return (await conn.QueryFirstOrDefaultAsync<ItemEntity>("SelectItemFromName", parameters,
            commandType: CommandType.StoredProcedure))!;
    }

    public async Task<ItemEntity> GetItem(int itemId)
    {
        await using SqlConnection conn = new(Secrets.itemsConnString);
        
        var parameters = new DynamicParameters();
        parameters.Add("@Id", itemId);

        return (await conn.QueryFirstOrDefaultAsync<ItemEntity>("SelectItemFromId", parameters,
            commandType: CommandType.StoredProcedure))!;
    }
}