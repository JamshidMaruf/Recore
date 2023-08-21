using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Suppliers;

public class Vehicle : Auditable
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string CarNumber { get; set; }
    public string Color { get; set; }
}