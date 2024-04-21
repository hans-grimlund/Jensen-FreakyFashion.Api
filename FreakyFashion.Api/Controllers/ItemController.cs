using FreakyFashion.Core.Interfaces;
using FreakyFashion.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(ILoggingService loggingService, IItemService itemService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddItem()
    {
        try
        {
            var formData = await Request.ReadFormAsync();
            var response = await itemService.AddItem(formData);
            return response switch
            {
                Status.Ok => Ok(),
                Status.BadRequest => BadRequest(),
                _ => throw new Exception("Failed to add item")
            };
        }
        catch (Exception e)
        {
            loggingService.LogError(e);
            return Problem();
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteItem([FromQuery]string sku)
    {
        try
        {
            var response = await itemService.DeleteItem(sku);
            return response switch
            {
                Status.Ok => Ok(),
                Status.NotFound => NotFound(),
                _ => throw new Exception("Failed to delete item")
            };
        }
        catch (Exception e)
        {
            loggingService.LogError(e);
            return Problem();
        }
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetItems([FromBody]Filters filters)
    {
        try
        {
            var response = await itemService.GetItems(filters);
            return response.Status switch
            {
                Status.Ok => Ok(response.Items),
                Status.NotFound => NotFound(),
                _ => throw new Exception("Failed to get items")
            };
        }
        catch (Exception e)
        {
            loggingService.LogError(e);
            return Problem();
        }
    }
}