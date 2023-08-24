using Recore.Domain.Enums;

namespace Recore.Service.DTOs.Products;

public class ProductCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Unit Unit { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}