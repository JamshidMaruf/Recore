using Recore.Service.DTOs.Addresses;
using Recore.Domain.Entities.Payments;

namespace Recore.Service.DTOs.Orders
{
	public class MainOrderDto
	{
		public string PromoCode { get; set; }
		public AddressCreationDto Address { get; set; }
		public Payment Payment { get; set; }
	}
}
