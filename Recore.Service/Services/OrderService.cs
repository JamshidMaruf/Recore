using Recore.Service.DTOs.Orders;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class OrderService : IOrderService
{
    public ValueTask<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<OrderResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
