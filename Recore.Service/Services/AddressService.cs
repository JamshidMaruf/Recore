using Recore.Service.DTOs.Addresses;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class AddressService : IAddressService
{
    public AddressService()
    {

    }

    public Task<AddressResultDto> AddAsync(AddressCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AddressResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AddressResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
