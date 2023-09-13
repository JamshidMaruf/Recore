using Recore.Service.DTOs.Addresses;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class AddressService : IAddressService
{
    public AddressService()
    {

    }

    public ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
