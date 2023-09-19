using Recore.Domain.Commons;
using Recore.Domain.Entities.Products;

namespace Recore.Domain.Entities.Orders;

public class OrderGift : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}
