using Recore.Domain.Configurations;

namespace Recore.Service.Interfaces;

public interface IBonusService
{
    ValueTask<object> RetrieveByIdAsync(long id);
    ValueTask<object> RetrieveAllAsync(PaginationParams @params);
}