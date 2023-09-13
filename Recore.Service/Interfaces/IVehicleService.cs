using Recore.Service.DTOs.Vehicles;

namespace Recore.Service.Interfaces;

public interface IVehicleService
{
    ValueTask<VehicleResultDto> AddAsync(VehicleCreationDto dto);
    ValueTask<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<VehicleResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<VehicleResultDto>> RetrieveAllAsync();
}
