using Recore.Domain.Configurations;
using Recore.Service.DTOs.Regions;

namespace Recore.Service.Interfaces;

public interface IRegionService
{
    Task<bool> SetAsync();
    Task<RegionResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params);
}
