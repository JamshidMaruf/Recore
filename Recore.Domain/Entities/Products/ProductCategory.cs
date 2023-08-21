using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Products;

public class ProductCategory : Auditable
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
