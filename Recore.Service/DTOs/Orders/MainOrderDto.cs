using Recore.Domain.Entities.Payments;
using Recore.Service.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recore.Service.DTOs.Orders
{
	public class MainOrderDto
	{
		public string PromoCode { get; set; }
		public AddressCreationDto Address { get; set; }
		public Payment Payment { get; set; }
	}
}
