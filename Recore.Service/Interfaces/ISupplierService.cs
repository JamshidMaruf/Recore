using Recore.Service.DTOs.Suppliers;

namespace Recore.Service.Interfaces;

public interface ISupplierService
{
    ValueTask<SupplierResultDto> AddAsync(SupplierCreationDto dto);
    ValueTask<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<SupplierResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<SupplierResultDto>> RetrieveAllAsync();
}
