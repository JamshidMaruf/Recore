using Recore.Service.DTOs.Suppliers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class SupplierService : ISupplierService
{
    public ValueTask<SupplierResultDto> AddAsync(SupplierCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<SupplierResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<SupplierResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
