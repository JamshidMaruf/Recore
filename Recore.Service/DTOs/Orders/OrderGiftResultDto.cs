using Recore.Service.DTOs.Products;

namespace Recore.Service.DTOs.Orders;

public class OrderGiftResultDto
{
    public long Id { get; set; }
    public OrderResultDto Order { get; set; }
    public ProductResultDto Product { get; set; }
}