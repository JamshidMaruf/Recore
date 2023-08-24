using Recore.Domain.Commons;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Payments;
using Recore.Domain.Entities.Suppliers;
using Recore.Domain.Entities.Users;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Orders;

public class Order : Auditable
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Status Status { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal TotalPrice { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
}