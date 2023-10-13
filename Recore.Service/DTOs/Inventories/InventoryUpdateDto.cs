namespace Recore.Service.DTOs.Inventories;

public class InventoryUpdateDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
    public long ProductId { get; set; }
    public long WarehouseId { get; set; }
}
