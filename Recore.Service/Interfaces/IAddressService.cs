using Recore.Domain.Configurations;
using Recore.Service.DTOs.Addresses;

namespace Recore.Service.Interfaces;

public interface IAddressService
{
    ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto);
    ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<AddressResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync();
    ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync(PaginationParams @params);
}
