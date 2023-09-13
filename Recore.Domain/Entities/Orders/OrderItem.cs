using Recore.Domain.Commons;
using Recore.Domain.Entities.Carts;
using Recore.Domain.Entities.Products;

namespace Recore.Domain.Entities.Orders;

public class OrderItem : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long ProductId { get; set; }
    public CartItem CartItem { get; set; }
}
