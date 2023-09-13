using Recore.Service.DTOs.Products;

namespace Recore.Service.DTOs.Carts;

public class CartItemResultDto
{
	public double Quantity { get; set; }
	public decimal Price { get; set; }
	public decimal Summ { get; set; }
	public CartResultDto Cart { get; set; }
	public ProductForRelationDto Product { get; set; }
}