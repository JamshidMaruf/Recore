using Recore.Domain.Enums;

namespace Recore.Service.DTOs.Payments;

public class PaymentUpdateDto
{
    public long Id { get; set; }
    public PaymentType Type { get; set; }
    public decimal Amount { get; set; }
}
