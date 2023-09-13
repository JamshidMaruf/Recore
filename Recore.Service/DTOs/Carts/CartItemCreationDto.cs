using Recore.Domain.Entities.Carts;
using Recore.Domain.Entities.Products;

namespace Recore.Service.DTOs.Carts;

public class CartItemCreationDto
{
	public double Quantity { get; set; }
	public decimal Price { get; set; }
	public int CartId { get; set; }
	public long ProductId { get; set; }
}
