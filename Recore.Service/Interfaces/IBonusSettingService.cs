using Recore.Domain.Configurations;
using Recore.Service.DTOs.BonusSetting;

namespace Recore.Service.Interfaces;

public interface IBonusSettingService
{
    ValueTask<BonusSettingResultDto> AddAsync(BonusSettingCreationDto dto);
    ValueTask<BonusSettingResultDto> ModifyAsync(BonusSettingUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<BonusSettingResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<BonusSettingResultDto>> RetrieveAllAsync(PaginationParams @params);
}