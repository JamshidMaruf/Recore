using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Orders;
using Recore.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Products;


namespace Recore.Service.Services;

public class OrderGiftService: IOrderGiftService
{
    private readonly IMapper mapper;
    private readonly IRepository<Order> orderRepository;
    private readonly IRepository<Product> productRepository;
    private readonly IRepository<OrderGift> orderGiftRepository;
    public OrderGiftService(
        IMapper mapper,
        IRepository<Order> orderRepository,
        IRepository<Product> productRepository,
        IRepository<OrderGift> orderGiftRepository)
    {
        this.mapper = mapper;
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
        this.orderGiftRepository = orderGiftRepository;
    }

    public async ValueTask<OrderGiftResultDto> AddAsync(OrderGiftCreationDto dto)
    {
        var existOrder = await this.orderRepository.SelectAsync(r => r.Id.Equals(dto.OrderId))
            ?? throw new NotFoundException($"This orderId was not found with {dto.OrderId}");

        var existProduct = await this.productRepository.SelectAsync(r => r.Id.Equals(dto.ProductId))
            ?? throw new NotFoundException($"This productId was not found with {dto.ProductId}");

        var mappedOrderGift = this.mapper.Map<OrderGift>(dto);
        await this.orderGiftRepository.CreateAsync(mappedOrderGift);
        await this.orderGiftRepository.SaveAsync();

        mappedOrderGift.Order = existOrder;
        mappedOrderGift.Product = existProduct;

        return this.mapper.Map<OrderGiftResultDto>(mappedOrderGift);
    }

    public async ValueTask<OrderGiftResultDto> ModifyAsync(OrderGiftUpdateDto dto)
    {
        var existOrderGift = await this.orderGiftRepository.SelectAsync(r => r.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This id was not found with {dto.Id}");

        var existOrder = await this.orderRepository.SelectAsync(r => r.Id.Equals(dto.OrderId))
            ?? throw new NotFoundException($"This orderId was not found with {dto.OrderId}");

        var existProduct = await this.productRepository.SelectAsync(r => r.Id.Equals(dto.ProductId))
            ?? throw new NotFoundException($"This productId was not found with {dto.ProductId}");

        existOrderGift.OrderId = existOrder.Id;
        existOrderGift.ProductId = existProduct.Id;

        this.mapper.Map(dto, existOrderGift);
        this.orderGiftRepository.Update(existOrderGift);
        await this.orderGiftRepository.SaveAsync();

        existOrderGift.Order = existOrder;
        existOrderGift.Product = existProduct;

        return mapper.Map<OrderGiftResultDto>(existOrderGift);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existOrderGift = await this.orderGiftRepository.SelectAsync(r => r.Id.Equals(id))
            ?? throw new NotFoundException($"This id was not found with {id}");

        this.orderGiftRepository.Delete(existOrderGift);
        await this.orderGiftRepository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<OrderGiftResultDto>> RetrieveAllAsync()
    {
        var orderGiftes = await this.orderGiftRepository.SelectAll(includes: new[] { "Order", "Product" })
            .ToListAsync();

        return this.mapper.Map<IEnumerable<OrderGiftResultDto>>(orderGiftes);
    }

    public async ValueTask<IEnumerable<OrderGiftResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var orderGiftes = await this.orderGiftRepository.SelectAll(includes: new[] { "Order", "Product", })
            .ToPaginate(@params)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<OrderGiftResultDto>>(orderGiftes);
    }

    public async ValueTask<OrderGiftResultDto> RetrieveByIdAsync(long id)
    {
        var existOrderGift = await this.orderGiftRepository.SelectAsync(p => p.Id.Equals(id),
            includes: new[] { "Order", "Product", })
            ?? throw new NotFoundException($"This id was not found with {id}");

        return this.mapper.Map<OrderGiftResultDto>(existOrderGift);
    }
}
