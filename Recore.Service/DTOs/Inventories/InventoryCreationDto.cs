namespace Recore.Service.DTOs.Inventories;

public class InventoryCreationDto
{
    public decimal Price { get; set; }
    public long Quantity { get; set; }
    public long ProductId { get; set; }
    public long WarehouseId { get; set; }
}