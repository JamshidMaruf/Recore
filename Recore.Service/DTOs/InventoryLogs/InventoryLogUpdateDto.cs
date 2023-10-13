namespace Recore.Service.DTOs.InventoryLogs;

public class InventoryLogUpdateDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
    public DateTime OperationDate { get; set; }
    public string Location { get; set; }
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public long WareohuseId { get; set; }
}
