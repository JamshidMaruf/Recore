using Recore.Service.DTOs.Carts;

namespace Recore.Service.Interfaces;

public interface ICartService
{
	ValueTask<CartResultDto> RetrieveByUserIdAsync(long userId);
}
