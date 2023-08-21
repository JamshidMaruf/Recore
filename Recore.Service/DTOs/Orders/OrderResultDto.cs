using Recore.Domain.Enums;
using Recore.Service.DTOs.Addresses;
using Recore.Service.DTOs.Suppliers;
using Recore.Service.DTOs.Users;

namespace Recore.Service.DTOs.Orders;

public class OrderResultDto
{
    public long Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Status Status { get; set; }
    public Payment Payment { get; set; }
    public decimal DeliveryFee { get; set; }
    public UserResultDto User { get; set; }
    public AddressResultDto Address { get; set; }
    public SupplierResultDto Supplier { get; set; }
}
