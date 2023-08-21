using Recore.Service.DTOs.Vehicles;

namespace Recore.Service.Interfaces;

public interface IVehicleService
{
    Task<VehicleResultDto> AddAsync(VehicleCreationDto dto);
    Task<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<VehicleResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<VehicleResultDto>> RetrieveAllAsync();
}
