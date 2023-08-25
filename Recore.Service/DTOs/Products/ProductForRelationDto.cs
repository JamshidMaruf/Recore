using Recore.Domain.Enums;

namespace Recore.Service.DTOs.Products;

public class ProductForRelationDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Quantity { get; set; }
    public Unit Unit { get; set; }
    public decimal Price { get; set; }
}