using Recore.Domain.Configurations;
using Recore.Service.DTOs.Addresses;

namespace Recore.Service.Interfaces;

public interface IAddressService
{
    Task<AddressResultDto> AddAsync(AddressCreationDto dto);
    Task<AddressResultDto> ModifyAsync(AddressUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<AddressResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<AddressResultDto>> RetrieveAllAsync();
    Task<IEnumerable<AddressResultDto>> RetrieveAllAsync(PaginationParams @params);
}
