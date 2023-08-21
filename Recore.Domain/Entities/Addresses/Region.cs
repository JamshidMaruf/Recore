using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Addresses;

public class Region : Auditable
{
    public string NameUz { get; set; }
    public string NameOz { get; set; }
    public string NameRu { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }
}
