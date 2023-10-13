using Recore.Domain.Configurations;
using Recore.Service.DTOs.BonusSetting;
using Recore.Service.DTOs.WareHouses;

namespace Recore.Service.Interfaces;

public interface IWarehouseService
{
	ValueTask<WarehouseResultDto> AddAsync(WareHouseCreationDto dto);
	ValueTask<WarehouseResultDto> ModifyAsync(WareHouseUpdateDto dto);
	ValueTask<bool> RemoveAsync(long id);
	ValueTask<WarehouseResultDto> RetrieveByIdAsync(long id);
	ValueTask<IEnumerable<WarehouseResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null);
	ValueTask<IEnumerable<WarehouseResultDto>> RetrieveAllAsync();
}
