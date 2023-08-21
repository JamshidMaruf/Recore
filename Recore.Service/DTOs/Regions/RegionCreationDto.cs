using Newtonsoft.Json;

namespace Recore.Service.DTOs.Regions;

public class RegionCreationDto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name_uz")]
    public string NameUz { get; set; }

    [JsonProperty("name_oz")]
    public string NameOz { get; set; }

    [JsonProperty("name_ru")]
    public string NameRu { get; set; }

    [JsonProperty("country_id")]
    public long CountryId { get; set; }
}
