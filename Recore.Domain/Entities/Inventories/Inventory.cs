using Recore.Domain.Commons;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Warehouses;

namespace Recore.Domain.Entities.Inventories;

public class Inventory : Auditable
{
    public decimal Price { get; set; }
    public double Quantity { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
}