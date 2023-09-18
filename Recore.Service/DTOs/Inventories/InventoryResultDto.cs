using Recore.Service.DTOs.Products;

namespace Recore.Service.DTOs.Inventories;

public class InventoryResultDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public long Quantity { get; set; }
    public ProductCreationDto Product { get; set; }
}