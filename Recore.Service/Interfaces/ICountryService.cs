using Recore.Domain.Configurations;
using Recore.Service.DTOs.Countries;

namespace Recore.Service.Interfaces;

public interface ICountryService
{
    ValueTask<bool> SetAsync();
    ValueTask<CountryResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams @params);
}