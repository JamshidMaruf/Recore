using Recore.Service.DTOs.Users;

namespace Recore.Service.DTOs.Carts;

public class CartResultDto
{
	public decimal TotalPrice { get; set; }
	public UserResultDto User { get; set; }
}

