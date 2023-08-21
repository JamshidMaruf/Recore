using Recore.Service.DTOs.Suppliers;

namespace Recore.Service.Interfaces;

public interface ISupplierService
{
    Task<SupplierResultDto> AddAsync(SupplierCreationDto dto);
    Task<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<SupplierResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<SupplierResultDto>> RetrieveAllAsync();
}
