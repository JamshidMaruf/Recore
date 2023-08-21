using Recore.Service.DTOs.Countries;

namespace Recore.Service.DTOs.Regions;

public class RegionResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CountryResultDto Country { get; set; }
}
