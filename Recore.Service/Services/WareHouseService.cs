using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Recore.Service.DTOs.WareHouses;
using Recore.Domain.Entities.Warehouses;

namespace Recore.Service.Services;

public class WarehouseService : IWarehouseService
{
	private readonly IMapper mapper;
	private readonly IRepository<Warehouse> repository;
	public WarehouseService(IRepository<Warehouse> repository, IMapper mapper)
	{
		this.mapper = mapper;
		this.repository = repository;
	}

	public async ValueTask<WarehouseResultDto> AddAsync(WareHouseCreationDto dto)
	{
		Warehouse existWareHouse = await this.repository.SelectAsync(u => u.Name.Equals(dto.Name));
		if (existWareHouse is not null)
			throw new AlreadyExistException($"This WareHouse is already exists with phone = {dto.Name}");

		var mappedWareHouse = this.mapper.Map<Warehouse>(dto);
		await this.repository.CreateAsync(mappedWareHouse);
		await this.repository.SaveAsync();

		var result = this.mapper.Map<WarehouseResultDto>(mappedWareHouse);
		return result;
	}

	public async ValueTask<WarehouseResultDto> ModifyAsync(WareHouseUpdateDto dto)
	{
		Warehouse existWareHouse = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id))
			?? throw new NotFoundException($"This WareHouse is not found with ID = {dto.Id}");

		this.mapper.Map(dto, existWareHouse);
		this.repository.Update(existWareHouse);
		await this.repository.SaveAsync();

		var result = this.mapper.Map<WarehouseResultDto>(existWareHouse);
		return result;
	}

	public async ValueTask<bool> RemoveAsync(long id)
	{
		Warehouse existWareHouse = await this.repository.SelectAsync(u => u.Id.Equals(id))
			?? throw new NotFoundException($"This WareHouse is not found with ID = {id}");

		this.repository.Delete(existWareHouse);
		await this.repository.SaveAsync();
		return true;
	}

	public async ValueTask<WarehouseResultDto> RetrieveByIdAsync(long id)
	{
		Warehouse existWareHouse = await this.repository.SelectAsync(u => u.Id.Equals(id))
			?? throw new NotFoundException($"This WareHouse is not found with ID = {id}");

		var result = this.mapper.Map<WarehouseResultDto>(existWareHouse);
		return result;
	}

	public async ValueTask<IEnumerable<WarehouseResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		var WareHouses = await this.repository.SelectAll()
			.ToPaginate(@params)
			.OrderBy(filter)
			.ToListAsync();

		var result = WareHouses.Where(WareHouse => WareHouse.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
		var mappedWareHouses = this.mapper.Map<List<WarehouseResultDto>>(result);
		return mappedWareHouses;
	}

	public async ValueTask<IEnumerable<WarehouseResultDto>> RetrieveAllAsync()
	{
		var WareHouses = await this.repository.SelectAll()
			.ToListAsync();
		var result = this.mapper.Map<IEnumerable<WarehouseResultDto>>(WareHouses);
		return result;
	}
}
