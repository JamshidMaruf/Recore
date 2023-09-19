using Recore.Domain.Entities.Carts;
using Recore.Domain.Entities.Products;

namespace Recore.Service.DTOs.Carts;

public class CartItemCreationDto
{
	public ICollection<CartItemDetail> Details { get; set; }
}
