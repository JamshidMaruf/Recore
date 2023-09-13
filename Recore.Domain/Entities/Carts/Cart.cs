using Recore.Domain.Commons;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Payments;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Suppliers;
using Recore.Domain.Entities.Users;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Carts;

public class Cart : Auditable
{

    public decimal TotalPrice { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}

public class CartItem : Auditable
{
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Summ { get; set; }
    public long CartId { get; set; }
    public Cart Cart { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}
