using Recore.Service.DTOs.Orders;
using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.WareHouses;

namespace Recore.Service.DTOs.InventoryLogs;

public class InventoryLogResultDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
    public DateTime OperationDate { get; set; }
    public string Location { get; set; }
    public OrderResultDto Order { get; set; }
    public ProductResultDto Product { get; set; }
    public WarehouseResultDto Warehouse { get; set; }
}