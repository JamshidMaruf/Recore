using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Recore.Service.DTOs.Suppliers;
using Recore.Domain.Entities.Suppliers;

namespace Recore.Service.Services;

public class SupplierService : ISupplierService
{
    private readonly IMapper mapper;
    private readonly IRepository<Supplier> repository;

    public SupplierService(IRepository<Supplier> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<SupplierResultDto> AddAsync(SupplierCreationDto dto)
    {
        var supplier = await this.repository.SelectAsync(c => c.Phone.Equals(dto.Phone));
        if (supplier is not null)
            throw new AlreadyExistException("This supplier is already exists");

        var mappedSupplier = this.mapper.Map<Supplier>(dto);
        await this.repository.CreateAsync(mappedSupplier);
        await this.repository.SaveAsync();

        return this.mapper.Map<SupplierResultDto>(mappedSupplier);
    }

    public async ValueTask<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto)
    {
        var existSupplier = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This supplier is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existSupplier);
        this.repository.Update(existSupplier);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<SupplierResultDto>(existSupplier);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existSupplier = await this.repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This supplier is not found with ID = {id}");

        this.repository.Delete(existSupplier);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<SupplierResultDto>> RetrieveAllAsync()
    {
        var supplier = await this.repository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<SupplierResultDto>>(supplier);
        return result;
    }

    public async ValueTask<SupplierResultDto> RetrieveByIdAsync(long id)
    {
        var supplier = await this.repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This supplier is not found with ID = {id}");

        var result = this.mapper.Map<SupplierResultDto>(supplier);
        return result;
    }
}