using Recore.Service.DTOs.Districts;
using Recore.Service.DTOs.Users;

namespace Recore.Service.Interfaces;

public interface IDistrictService
{
    Task<bool> SetAsync();
    Task<DistrictResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<DistrictResultDto>> RetrieveAllAsync();
}
