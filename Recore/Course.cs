using Newtonsoft.Json;

namespace Recore.Console;

public class Address
{
    [JsonProperty("regionId")]
    public long RegionId { get; set; }

    [JsonProperty("districtId")]
    public long DistrictId { get; set; }

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("department")]
    public string Department { get; set; }

    [JsonProperty("home")]
    public string Home { get; set; }

    [JsonProperty("domofonCode")]
    public string DomofonCode { get; set; }

    [JsonProperty("floor")]
    public string Floor { get; set; }

    [JsonProperty("latitude")]
    public string Latitude { get; set; }

    [JsonProperty("longitude")]
    public string Longitude { get; set; }
}

public class Speaker
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("phone_number")]
    public string Phone { get; set; }

    [JsonProperty("sex")]
    public string Sex { get; set; }

    [JsonProperty("about_me")]
    public string About { get; set; }
}
