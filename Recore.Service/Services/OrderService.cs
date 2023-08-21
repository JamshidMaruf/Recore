using Recore.Service.DTOs.Orders;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class OrderService : IOrderService
{
    public Task<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
