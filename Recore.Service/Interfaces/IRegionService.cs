using Recore.Domain.Configurations;
using Recore.Service.DTOs.Regions;

namespace Recore.Service.Interfaces;

public interface IRegionService
{
    ValueTask<bool> SetAsync();
    ValueTask<RegionResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params);
}
