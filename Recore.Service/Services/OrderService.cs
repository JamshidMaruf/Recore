using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Orders;
using Recore.Service.DTOs.Orders;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class OrderService : IOrderService
{
    private readonly IMapper mapper;
    private readonly IRepository<Order> repository;
	public OrderService(IMapper mapper, IRepository<Order> repository)
	{
		this.mapper = mapper;
		this.repository = repository;
	}

	public async ValueTask<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        var mappedOrder = this.mapper.Map<Order>(dto);
        await this.repository.CreateAsync(mappedOrder);

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

    public ValueTask<IEnumerable<OrderResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
