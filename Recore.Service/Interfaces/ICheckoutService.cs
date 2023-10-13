using Recore.Service.DTOs.Orders;

namespace Recore.Service.Interfaces;

public interface ICheckoutService
{
	ValueTask<OrderResultDto> SetOrderAsync(MainOrderDto dto);
}
