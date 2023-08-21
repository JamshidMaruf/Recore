using Recore.Domain.Commons;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Quantity { get; set; }
    public Unit Unit { get; set; }
    public decimal Price { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }
}
