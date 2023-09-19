using Recore.Domain.Configurations;
using Recore.Service.DTOs.Payments;

namespace Recore.Service.Interfaces;

public interface IPaymentService
{
    ValueTask<PaymentResultDto> AddAsync(PaymentCreationDto dto);
    ValueTask<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<PaymentResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null);
}
