using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Addresses;

public class District : Auditable
{
    public string NameUz { get; set; }
    public string NameOz { get; set; }
    public string NameRu { get; set; }
    public long RegionId { get; set; }
    public Region Region { get; set; }
}