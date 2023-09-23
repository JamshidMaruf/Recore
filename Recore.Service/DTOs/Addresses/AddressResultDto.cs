using Recore.Service.DTOs.Regions;
using Recore.Service.DTOs.Countries;
using Recore.Service.DTOs.Districts;

namespace Recore.Service.DTOs.Addresses;

public class AddressResultDto
{
    public long Id { get; set; }
    public string Street { get; set; }
    public string Floor { get; set; }
    public string Home { get; set; }
    public string DoorCode { get; set; }
    public CountryResultDto Country { get; set; }
    public RegionResultDto Region { get; set; }
    public DistrictResultDto District { get; set; }
}
