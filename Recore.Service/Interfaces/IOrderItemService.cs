using Recore.Service.DTOs.Orders;

namespace Recore.Service.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemResultDto> AddAsync(OrderItemCreationDto dto);
    Task<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<OrderItemResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<OrderItemResultDto>> RetrieveAllAsync();
}
