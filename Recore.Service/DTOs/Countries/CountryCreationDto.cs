using Newtonsoft.Json;

namespace Recore.Service.DTOs.Countries;

public class CountryCreationDto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("code")]
	public string CountryCode { get; set; }
}