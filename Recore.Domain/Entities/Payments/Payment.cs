using Recore.Domain.Commons;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Payments;

public class Payment : Auditable
{
	public PaymentType Type { get; set; }
	public decimal Amount { get; set; }
}
