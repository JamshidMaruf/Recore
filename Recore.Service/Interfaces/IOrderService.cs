using Recore.Domain.Configurations;
using Recore.Service.DTOs.Orders;

namespace Recore.Service.Interfaces;

public interface IOrderService
{
    ValueTask<OrderResultDto> AddAsync(OrderCreationDto dto);
    ValueTask<OrderResultDto> ModifyAsync(OrderUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<OrderResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<OrderResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null);
}