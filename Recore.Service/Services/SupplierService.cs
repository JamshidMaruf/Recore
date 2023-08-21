using Recore.Service.DTOs.Suppliers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class SupplierService : ISupplierService
{
    public Task<SupplierResultDto> AddAsync(SupplierCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SupplierResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
