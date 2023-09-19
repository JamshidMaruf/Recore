using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Orders;
using Recore.Service.DTOs.Orders;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
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
        await this.repository.SaveAsync();

        return this.mapper.Map<OrderResultDto>(mappedOrder);
    }

    public async ValueTask<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        Order order = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This Order is not found with ID = {dto.Id}");

        this.mapper.Map(dto, order);
        this.repository.Update(order);
        await this.repository.SaveAsync();

        return this.mapper.Map<OrderResultDto>(order);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        Order order = await this.repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Order is not found with ID = {id}");

        this.repository.Delete(order);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<OrderResultDto> RetrieveByIdAsync(long id)
    {
        Order order = await this.repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Order is not found with ID = {id}");

        return this.mapper.Map<OrderResultDto>(order);
    }

    public async ValueTask<IEnumerable<OrderResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var orders = await this.repository.SelectAll()
            .ToPaginate(@params)
            .ToListAsync();

        var mappedOrders = this.mapper.Map<List<OrderResultDto>>(orders);
        return mappedOrders;
    }
}
