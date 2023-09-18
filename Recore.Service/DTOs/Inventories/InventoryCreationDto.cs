namespace Recore.Service.DTOs.Inventories;

public class InventoryCreationDto
{
    public double Price { get; set; }
    public long Quantity { get; set; }
    public long ProductId { get; set; }
}