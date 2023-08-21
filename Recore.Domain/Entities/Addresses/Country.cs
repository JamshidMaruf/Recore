using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Addresses;

public class Country : Auditable
{
    public string Name { get; set; }
    public string CountryCode { get; set; }
}