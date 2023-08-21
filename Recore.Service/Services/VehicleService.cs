using Recore.Service.DTOs.Vehicles;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class VehicleService : IVehicleService
{
    public Task<VehicleResultDto> AddAsync(VehicleCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VehicleResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<VehicleResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
