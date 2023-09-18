using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Products;
using Recore.Service.DTOs.Inventories;
using Recore.Domain.Entities.Inventories;

namespace Recore.Service.Services;

public class InventoryService : IInventoryService
{
    private readonly IMapper mapper;
    private readonly IRepository<Product> productRepository;
    private readonly IRepository<Inventory> inventoryRepository;
    public InventoryService(
        IMapper mapper,
        IRepository<Product> productRepository,
        IRepository<Inventory> inventoryRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.inventoryRepository = inventoryRepository;
    }

    public async ValueTask<InventoryResultDto> AddAsync(InventoryCreationDto dto)
    {
        var product = await this.productRepository.SelectAsync(product => product.Id.Equals(dto.ProductId))
                      ?? throw new NotFoundException("This product is not found");

        var mappedInventory = this.mapper.Map<Inventory>(dto);
        mappedInventory.ProductId = product.Id;
        await this.inventoryRepository.CreateAsync(mappedInventory);
        await this.inventoryRepository.SaveAsync();
        mappedInventory.Product = product;

        return this.mapper.Map<InventoryResultDto>(mappedInventory);
    }

    public async ValueTask<InventoryResultDto> ModifyAsync(InventoryUpdateDto dto)
    {
        var existInventory = await this.inventoryRepository.SelectAsync(inventory => inventory.Id.Equals(dto.Id))
                             ?? throw new NotFoundException("This inventory is not found");

        var product = await this.productRepository.SelectAsync(product => product.Id.Equals(dto.ProductId))
                      ?? throw new NotFoundException("This product is not found");

        var mappedInventory = this.mapper.Map(dto, existInventory);
        mappedInventory.ProductId = product.Id;
        this.inventoryRepository.Update(mappedInventory);
        await this.inventoryRepository.SaveAsync();
        mappedInventory.Product = product;

        return this.mapper.Map<InventoryResultDto>(mappedInventory);

    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existInventory = await this.inventoryRepository.SelectAsync(inventory => inventory.Id.Equals(id))
                             ?? throw new NotFoundException("This inventory is not found");

        this.inventoryRepository.Delete(existInventory);
        await this.inventoryRepository.SaveAsync();
        return true;
    }

    public async ValueTask<InventoryResultDto> RetrieveByIdAsync(long id)
    {
        var existInventory = 
            await this.inventoryRepository.SelectAsync(inventory => inventory.Id.Equals(id), includes: new[] { "Product" })
            ?? throw new NotFoundException("This inventory is not found");

        return this.mapper.Map<InventoryResultDto>(existInventory);
    }

    public async ValueTask<IEnumerable<InventoryResultDto>> RetrieveAllAsync()
    {
        var inventories = await this.inventoryRepository.SelectAll(includes: new[] { "Product" }).ToListAsync();
        var result = this.mapper.Map<IEnumerable<InventoryResultDto>>(inventories);
        return result;
    }
}