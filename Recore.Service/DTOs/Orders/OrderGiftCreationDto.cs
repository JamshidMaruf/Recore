using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Products;

namespace Recore.Service.DTOs.Orders;

public class OrderGiftCreationDto
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
}
