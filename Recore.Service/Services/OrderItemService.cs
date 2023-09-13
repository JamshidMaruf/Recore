using Recore.Service.DTOs.Orders;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class OrderItemService : IOrderItemService
{
    public ValueTask<OrderItemResultDto> AddAsync(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<OrderItemResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderItemResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
