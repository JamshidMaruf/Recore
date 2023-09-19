using Recore.Domain.Configurations;
using Recore.Service.DTOs.Orders;

namespace Recore.Service.Interfaces;

public interface IOrderGiftService
{
    ValueTask<OrderGiftResultDto> AddAsync(OrderGiftCreationDto dto);
    ValueTask<OrderGiftResultDto> ModifyAsync(OrderGiftUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<OrderGiftResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<OrderGiftResultDto>> RetrieveAllAsync();
    ValueTask<IEnumerable<OrderGiftResultDto>> RetrieveAllAsync(PaginationParams @params);
}
