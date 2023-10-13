using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.WareHouses;

namespace Recore.Service.DTOs.Inventories;

public class InventoryResultDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
    public ProductResultDto Product { get; set; }
    public WarehouseResultDto Warehouse { get; set; }
}