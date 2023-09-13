using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recore.Data.IRepositories;
using Recore.Domain.Entities.Suppliers;
using Recore.Domain.Entities.Users;
using Recore.Service.DTOs.Users;
using Recore.Service.DTOs.Vehicles;
using Recore.Service.Exceptions;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class VehicleService : IVehicleService
{
    private readonly IMapper mapper;
    private readonly IRepository<Vehicle> repository;
    public VehicleService(IRepository<Vehicle> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async ValueTask<VehicleResultDto> AddAsync(VehicleCreationDto dto)
    {
        var mappedVehicle = this.mapper.Map<Vehicle>(dto);
        await this.repository.CreateAsync(mappedVehicle);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<VehicleResultDto>(mappedVehicle);
        return result;
    }

    public async ValueTask<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto)
    {
        Vehicle vehicle = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (vehicle is null)
            throw new NotFoundException($"This vehicle is not found with ID = {dto.Id}");

        this.mapper.Map(dto, vehicle);
        this.repository.Update(vehicle);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<VehicleResultDto>(vehicle);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        Vehicle vehicle = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (vehicle is null)
            throw new NotFoundException($"This vehicle is not found with ID = {id}");

        this.repository.Delete(vehicle);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<VehicleResultDto>> RetrieveAllAsync()
    {
        var vehicle = await this.repository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<VehicleResultDto>>(vehicle);
        return result;
    }

    public async ValueTask<VehicleResultDto> RetrieveByIdAsync(long id)
    {
        Vehicle vehicle = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (vehicle is null)
            throw new NotFoundException($"This vehicle is not found with ID = {id}");

        var result = this.mapper.Map<VehicleResultDto>(vehicle);
        return result;
    }
}
