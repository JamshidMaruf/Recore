using Recore.Domain.Configurations;
using Recore.Service.DTOs.Countries;

namespace Recore.Service.Interfaces;

public interface ICountryService
{
    Task<bool> SetAsync();
    Task<CountryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams @params);
}