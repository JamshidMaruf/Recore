using Recore.Service.DTOs.Regions;

namespace Recore.Service.DTOs.Districts;

public class DistrictResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public RegionResultDto Region { get; set; }
}

