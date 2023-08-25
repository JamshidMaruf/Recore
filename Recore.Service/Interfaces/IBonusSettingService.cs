using Recore.Domain.Configurations;

namespace Recore.Service.Interfaces;

public interface IBonusSettingService
{
    ValueTask<object> AddAsync(object dto);
    ValueTask<object> ModifyAsync(object dto);
    ValueTask<object> RemoveAsync(long id);
    ValueTask<object> RetrieveByIdAsync(long id);
    ValueTask<object> RetrieveAllAsync(PaginationParams @params);
}