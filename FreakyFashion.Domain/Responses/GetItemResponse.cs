namespace FreakyFashion.Domain.Responses;

public class GetItemResponse
{
    public ItemDto Item { get; set; }
    public List<ItemDto> Items { get; set; }
    public Status Status { get; set; }

    public GetItemResponse(ItemDto? item = null, List<ItemDto>? items = null, Status status = default)
    {
        Item = item ?? new ItemDto();
        Items = items ?? [];
        Status = status;
    }

    public GetItemResponse()
    {
        Item ??= new ItemDto();
        Items ??= [];
    }
}