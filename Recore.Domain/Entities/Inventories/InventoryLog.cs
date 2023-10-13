using Recore.Domain.Commons;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Warehouses;

namespace Recore.Domain.Entities.Inventories;

public class InventoryLog : Auditable
{
    public double Price { get; set; }
    public long Quantity { get; set; }
    public DateTime OperationDate { get; set; }
    public string Location { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
}