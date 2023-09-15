using Recore.Domain.Entities.Carts;
using Recore.Domain.Entities.Products;

namespace Recore.Service.DTOs.Carts;

public class CartItemCreationDto
{
	public List<CartItemDetail> Details { get; set; } = new();
}
