using Recore.Domain.Enums;
using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Payments;

public class Payment : Auditable
{
	public PaymentType Type { get; set; }
	public decimal Amount { get; set; }
}