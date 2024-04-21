using System.Data.Common;

namespace FreakyFashion.Domain;

public class Filters
{
    public int Start { get; set; }
    public int End { get; set; }
    public string SearchTerm { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }

    public Filters(int start, int end, string? searchTerm, int itemId, string? itemName)
    {
        Start = start;
        End = end;
        SearchTerm = searchTerm ?? "";
        ItemId = itemId;
        ItemName = itemName ?? "";
    }

    public Filters()
    {
        SearchTerm ??= "";
        ItemName ??= "";
    }
}