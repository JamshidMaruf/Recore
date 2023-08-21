namespace Recore.Service.DTOs.Orders;

public class OrderItemUpdateDto
{
    public long Id { get; set; }
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
}
