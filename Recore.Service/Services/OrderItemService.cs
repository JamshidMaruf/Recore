using Recore.Service.DTOs.Orders;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class OrderItemService : IOrderItemService
{
    public Task<OrderItemResultDto> AddAsync(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItemResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
