using Recore.Domain.Configurations;
using Recore.Service.DTOs.Districts;

namespace Recore.Service.Interfaces;

public interface IDistrictService
{
    ValueTask<bool> SetAsync();
    ValueTask<DistrictResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync(PaginationParams @params);
}
