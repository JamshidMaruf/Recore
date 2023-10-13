using Recore.Service.DTOs.Regions;
using Recore.Domain.Configurations;

namespace Recore.Service.Interfaces;

public interface IRegionService
{
    ValueTask<bool> SetAsync();
    ValueTask<RegionResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params);
}
