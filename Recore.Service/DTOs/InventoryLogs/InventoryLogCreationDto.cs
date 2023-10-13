using Recore.Domain.Entities.Products;

namespace Recore.Service.DTOs.InventoryLogs;

public class InventoryLogCreationDto
{
    public double Price { get; set; }
    public long Quantity { get; set; }
    public DateTime OperationDate { get; set; }
    public string Location { get; set; }
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public long WarehouseId { get; set; }
}