using Recore.Service.DTOs.Inventories;

namespace Recore.Service.Interfaces;

public interface IInventoryService
{
    ValueTask<InventoryResultDto> AddAsync(InventoryCreationDto dto);
    ValueTask<InventoryResultDto> ModifyAsync(InventoryUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<InventoryResultDto> RetrieveByIdAsync(long id);
    ValueTask<InventoryResultDto> RetrieveStockAsync(long productId);
    ValueTask<IEnumerable<InventoryResultDto>> RetrieveAllAsync();
}