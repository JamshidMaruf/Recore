using Recore.Domain.Commons;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Payments;
using Recore.Domain.Entities.Suppliers;
using Recore.Domain.Entities.Users;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Carts;

public class Cart : Auditable
{
    public decimal TotalPrice { get; set; }
    public long? UserId { get; set; }
    public User User { get; set; }
}
