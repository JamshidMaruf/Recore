using Recore.Service.DTOs.InventoryLogs;

namespace Recore.Service.Interfaces;

public interface IInventoryLogService
{
    ValueTask<InventoryLogResultDto> AddAsync(InventoryLogCreationDto dto);
    ValueTask<InventoryLogResultDto> ModifyAsync(InventoryLogUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<InventoryLogResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<InventoryLogResultDto>> RetrieveAllAsync();
}