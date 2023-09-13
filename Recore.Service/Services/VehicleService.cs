using Recore.Service.DTOs.Vehicles;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class VehicleService : IVehicleService
{
    public ValueTask<VehicleResultDto> AddAsync(VehicleCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<VehicleResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<VehicleResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
