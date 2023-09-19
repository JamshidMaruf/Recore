using Recore.Domain.Enums;

namespace Recore.Service.DTOs.Payments;

public class PaymentCreationDto
{
    public PaymentType Type { get; set; }
    public decimal Amount { get; set; }
}