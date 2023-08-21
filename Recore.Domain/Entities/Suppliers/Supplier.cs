using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Suppliers;

public class Supplier : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}


