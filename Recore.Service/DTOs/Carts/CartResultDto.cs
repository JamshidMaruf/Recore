using Recore.Service.DTOs.Users;

namespace Recore.Service.DTOs.Carts;

public class CartResultDto
{
	public long Id { get; set; }
	public decimal TotalPrice { get; set; }
	public UserResultDto User { get; set; }
}

