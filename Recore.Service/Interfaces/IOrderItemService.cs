using Recore.Domain.Configurations;
using Recore.Service.DTOs.Orders;

namespace Recore.Service.Interfaces;

public interface IOrderItemService
{
    ValueTask<OrderItemResultDto> AddAsync(OrderItemCreationDto dto);
    ValueTask<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<OrderItemResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<OrderItemResultDto>> RetrieveAllAsync();
}
