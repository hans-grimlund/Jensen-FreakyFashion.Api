namespace FreakyFashion.Domain;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ItemDto(int id, string name, string displayName, string description)
    {
        Id = id;
        Name = name ?? "";
        DisplayName = displayName ?? "";
        Description = description ?? "";
    }

    public ItemDto()
    {
        Name ??= "";
        DisplayName ??= "";
        Description ??= "";
    }
}

public class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ItemEntity(int id, string name, string displayName, string description)
    {
        Id = id;
        Name = name ?? "";
        DisplayName = displayName ?? "";
        Description = description ?? "";
    }

    public ItemEntity()
    {
        Name ??= "";
        DisplayName ??= "";
        Description ??= "";
    }
}

public class ItemCreate
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ItemCreate(string name, string displayName, string description)
    {
        Name = name ?? "";
        DisplayName = displayName ?? "";
        Description = description ?? "";
    }

    public ItemCreate()
    {
        Name ??= "";
        DisplayName ??= "";
        Description ??= "";
    }
}