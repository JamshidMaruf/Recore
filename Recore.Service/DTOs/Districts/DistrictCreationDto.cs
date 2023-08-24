using Newtonsoft.Json;

namespace Recore.Service.DTOs.Districts;

public class DistrictCreationDto
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("name_uz")]
	public string NameUz { get; set; }

	[JsonProperty("name_oz")]
	public string NameOz { get; set; }

	[JsonProperty("name_ru")]
	public string NameRu { get; set; }

	[JsonProperty("region_id")]
	public long RegionId { get; set; }
}

