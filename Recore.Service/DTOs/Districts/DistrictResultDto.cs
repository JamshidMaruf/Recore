using Recore.Domain.Entities.Addresses;
using Recore.Service.DTOs.Regions;

namespace Recore.Service.DTOs.Districts;

public class DistrictResultDto
{
	public long Id { get; set; }
	public string NameUz { get; set; }
	public string NameOz { get; set; }
	public string NameRu { get; set; }
	public RegionResultDto Region { get; set; }
}

