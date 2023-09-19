using Recore.Domain.Commons;
using Recore.Domain.Entities.Products;

namespace Recore.Domain.Entities.Inventories;

public class Inventory : Auditable
{
    public double Price { get; set; }
    public long Quantity { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}